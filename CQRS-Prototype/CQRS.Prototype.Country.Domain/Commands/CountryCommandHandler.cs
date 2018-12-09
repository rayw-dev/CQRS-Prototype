using CQRS.Prototype.Country.Domain.Events;
using CQRS.Prototype.Country.Domain.Interfaces;
using CQRS.Prototype.Country.Domain.Queries;
using CQRS_Prototype.Domain.Core.Commands;
using CQRS_Prototype.Domain.Core.Events;
using CQRS_Prototype.Domain.Core.Extensions;
using CQRS_Prototype.Domain.Core.Interfaces;
using CQRS_Prototype.Domain.Core.Models;
using CQRS_Prototype.Domain.Core.Notifications;
using CQRS_Prototype.Domain.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Prototype.Country.Domain.Commands
{
    public class CountryCommandHandler : CommandHandler,
        IRequestHandler<CreateCountryCommand, IActionResponse<Models.Country>>,
        IRequestHandler<UpdateCountryCommand, IActionResponse<Models.Country>>,
        IRequestHandler<DeleteCountryCommand, IActionResponse<Models.Country>>,
        IRequestHandler<CountryListQuery, IActionResponse<PagedResult<Models.Country>>>
    {
        readonly ICountryService _countryService;

        public CountryCommandHandler(ICountryService countryService,
                                        IUnitOfWork uow,
                                        IMediatorHandler bus,
                                        INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _countryService = countryService;
        }

        public async Task<IActionResponse<Models.Country>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var response = new ActionResponse<Models.Country> { Success = true };

            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                response.Success = false;
                request.ValidationResult.Errors.ToList().ForEach(e => response.ErrorMessages.Add(e.ErrorMessage));
                return response;
            }

            var existingCountry = await _countryService.FetchByAlpha3Code(request.Alpha3Code);
            if (existingCountry.Success && existingCountry.Data != null && existingCountry.Data.Id > 0)
            {
                var errorMessage = $"Country {request.EnglishName} ({request.Alpha3Code}) already exists.";
                await Bus.RaiseEvent(new DomainNotification(EventType.Error,
                    "Country Exists",
                    errorMessage));
                response.Success = false;
                response.ErrorMessages.Add(errorMessage);
                return response;
            }

            var createResponse = await _countryService.Create(new Models.Country(request));
            response.MergeResponse(createResponse);
            Bus.RaiseOnResponse(response, $"Error Creating Country {request.EnglishName} ({request.Alpha3Code})");
            if (response.Success && Commit())
            {
                response.Data = createResponse.Data;
                await Bus.RaiseEvent(new CountryCreatedEvent(response.Data));
            }
            return response;
        }

        public async Task<IActionResponse<Models.Country>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var response = new ActionResponse<Models.Country> { Success = true };

            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                response.Success = false;
                request.ValidationResult.Errors.ToList().ForEach(e => response.ErrorMessages.Add(e.ErrorMessage));
                return response;
            }

            var existingCountry = await _countryService.FetchSingle(request.Id);
            if (existingCountry.Data == null || existingCountry.Data.Id < 1)
            {
                var errorMessage = $"Country {request.EnglishName} ({request.Alpha3Code}) does not exist.";
                await Bus.RaiseEvent(new DomainNotification(EventType.Error,
                    "Country Does Not Exist",
                    errorMessage));
                response.Success = false;
                response.ErrorMessages.Add(errorMessage);
                return response;
            }

            var updateResponse = await _countryService.Update(new Models.Country(request));
            response.MergeResponse(updateResponse);
            Bus.RaiseOnResponse(response, $"Error Updating Country {request.EnglishName} ({request.Alpha3Code})");
            if (response.Success && Commit())
            {
                response.Data = updateResponse.Data;
                await Bus.RaiseEvent(new CountryUpdatedEvent(response.Data));
            }
            return response;
        }

        public async Task<IActionResponse<Models.Country>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var response = new ActionResponse<Models.Country> { Success = true };

            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                response.Success = false;
                request.ValidationResult.Errors.ToList().ForEach(e => response.ErrorMessages.Add(e.ErrorMessage));
                return response;
            }

            var existingCountry = await _countryService.FetchSingle(request.Id);
            if (existingCountry.Data == null || existingCountry.Data.Id < 1)
            {
                var errorMessage = $"Country {request.EnglishName} ({request.Alpha3Code}) does not exist.";
                await Bus.RaiseEvent(new DomainNotification(EventType.Error,
                    "Country Does Not Exist",
                    errorMessage));
                response.Success = false;
                response.ErrorMessages.Add(errorMessage);
                return response;
            }

            var deleteResponse = await _countryService.Delete(new Models.Country(request));
            response.MergeResponse(deleteResponse);
            Bus.RaiseOnResponse(response, $"Error Deleting Country {request.EnglishName} ({request.Alpha3Code})");
            if (response.Success && Commit())
            {
                response.Data = deleteResponse.Data;
                await Bus.RaiseEvent(new CountryDeletedEvent(response.Data));
            }
            return response;
        }

        public async Task<IActionResponse<PagedResult<Models.Country>>> Handle(CountryListQuery request, CancellationToken cancellationToken)
        {
            var response = new ActionResponse<PagedResult<Models.Country>> { Success = true, Data = new PagedResult<Models.Country>() };
            var queryResult = await _countryService.FetchList(request);
            response.MergeResponse(queryResult);
            Bus.RaiseOnResponse(response, $"Error During Country Query");
            if (response.Success)
            {
                response.Data = queryResult.Data;
            }
            return response;
        }
    }
}

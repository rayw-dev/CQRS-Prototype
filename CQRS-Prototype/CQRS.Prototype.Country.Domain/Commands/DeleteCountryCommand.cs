using CQRS.Prototype.Country.Domain.Validators;
using CQRS_Prototype.Domain.Core.Interfaces;
using MediatR;

namespace CQRS.Prototype.Country.Domain.Commands
{
    public class DeleteCountryCommand : CountryCommand, IRequest<IActionResponse<Models.Country>>
    {
        public DeleteCountryCommand(string englishName, string alpha3Code) : base(new Models.Country { EnglishName = englishName, Alpha3Code = alpha3Code })
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteCountryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

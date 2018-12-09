using CQRS.Prototype.Country.Domain.Validators;
using CQRS_Prototype.Domain.Core.Interfaces;
using MediatR;

namespace CQRS.Prototype.Country.Domain.Commands
{
    public class UpdateCountryCommand : CountryCommand, IRequest<IActionResponse<Models.Country>>
    {
        public UpdateCountryCommand(Interfaces.ICountry country) : base(country)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCountryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

using CQRS.Prototype.Country.Domain.Validators;
using CQRS_Prototype.Domain.Core.Interfaces;
using MediatR;

namespace CQRS.Prototype.Country.Domain.Commands
{
    public class CreateCountryCommand : CountryCommand, IRequest<IActionResponse<Models.Country>>
    {
        public CreateCountryCommand(Interfaces.ICountry country) : base(country)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateCountryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

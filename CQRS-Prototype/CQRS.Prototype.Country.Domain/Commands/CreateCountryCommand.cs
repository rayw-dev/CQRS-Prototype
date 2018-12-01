using CQRS.Prototype.Country.Domain.Interfaces;
using CQRS.Prototype.Country.Domain.Validators;

namespace CQRS.Prototype.Country.Domain.Commands
{
    public class CreateCountryCommand : CountryCommand
    {
        public CreateCountryCommand(ICountry country) : base(country)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateCountryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

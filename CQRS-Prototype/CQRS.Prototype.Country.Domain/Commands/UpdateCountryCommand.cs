using CQRS.Prototype.Country.Domain.Interfaces;
using CQRS.Prototype.Country.Domain.Validators;

namespace CQRS.Prototype.Country.Domain.Commands
{
    public class UpdateCountryCommand : CountryCommand
    {
        public UpdateCountryCommand(ICountry country) : base(country)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCountryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

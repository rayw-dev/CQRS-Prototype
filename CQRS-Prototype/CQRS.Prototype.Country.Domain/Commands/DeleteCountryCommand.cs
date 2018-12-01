using CQRS.Prototype.Country.Domain.Validators;

namespace CQRS.Prototype.Country.Domain.Commands
{
    public class DeleteCountryCommand : CountryCommand
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

using CQRS.Prototype.Country.Domain.Commands;

namespace CQRS.Prototype.Country.Domain.Validators
{
    public class CreateCountryValidation : CountryValidation<CreateCountryCommand>
    {
        public CreateCountryValidation()
        {
            FullValidation();
        }
    }
}

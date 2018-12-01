using CQRS.Prototype.Country.Domain.Commands;

namespace CQRS.Prototype.Country.Domain.Validators
{
    public class UpdateCountryValidation : CountryValidation<UpdateCountryCommand>
    {
        public UpdateCountryValidation()
        {
            FullValidation();
        }
    }
}

using CQRS.Prototype.Country.Domain.Commands;

namespace CQRS.Prototype.Country.Domain.Validators
{
    public class DeleteCountryValidation : CountryValidation<DeleteCountryCommand>
    {
        public DeleteCountryValidation()
        {
            DeleteValidation();
        }
    }
}

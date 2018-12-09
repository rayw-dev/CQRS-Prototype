using CQRS_Prototype.Domain.Core.Interfaces;

namespace CQRS.Prototype.Country.Persistence.EntityFramework
{
    public class CountryUow : IUnitOfWork
    {
        readonly CountryContext _context;
        public CountryUow(CountryContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            //_context.Dispose(); ??? TEST
        }
    }
}

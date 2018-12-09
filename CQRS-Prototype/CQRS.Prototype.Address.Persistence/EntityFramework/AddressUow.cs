using CQRS_Prototype.Domain.Core.Interfaces;

namespace CQRS.Prototype.Address.Persistence.EntityFramework
{
    public class AddressUow : IUnitOfWork
    {
        readonly AddressContext _context;
        public AddressUow(AddressContext context)
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

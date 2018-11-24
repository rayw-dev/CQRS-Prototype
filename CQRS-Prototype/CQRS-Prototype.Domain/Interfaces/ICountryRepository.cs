namespace CQRS_Prototype.Domain.Interfaces
{
    public interface ICountryRepository<C, TKey> : IRepository<C, TKey> where C : class, ICountry<TKey>
    {
    }
}

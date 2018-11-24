namespace CQRS_Prototype.Domain.Interfaces
{
    public interface IAddressRepository<A, C, TKey> : IRepository<A, TKey> where A : class, IAddress<C, TKey> where C : class, ICountry<TKey>
    {
    }
}

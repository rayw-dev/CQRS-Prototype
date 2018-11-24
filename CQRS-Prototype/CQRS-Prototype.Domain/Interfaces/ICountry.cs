using CQRS_Prototype.Domain.Core.Interfaces;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface ICountry<TKey> : IEntity<TKey>
    {
        string CountryName { get; set; }
        string CountryCode { get; set; }
    }
}

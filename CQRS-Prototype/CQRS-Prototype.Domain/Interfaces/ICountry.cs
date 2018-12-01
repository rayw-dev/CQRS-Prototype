using CQRS_Prototype.Domain.Core.Interfaces;
using System;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface ICountry : IEntity<long>
    {
        string CountryName { get; set; }
        string CountryCode { get; set; }
    }
}

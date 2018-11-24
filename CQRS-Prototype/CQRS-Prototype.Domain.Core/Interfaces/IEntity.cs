using System;

namespace CQRS_Prototype.Domain.Core.Interfaces
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}

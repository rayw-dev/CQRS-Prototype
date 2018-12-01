﻿using CQRS_Prototype.Domain.Entities;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface IAddressRepository : IRepository<Address, long>
    {
    }
}

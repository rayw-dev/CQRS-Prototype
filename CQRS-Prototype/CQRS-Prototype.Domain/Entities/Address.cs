﻿using CQRS_Prototype.Domain.Core.Models;
using CQRS_Prototype.Domain.Interfaces;

namespace CQRS_Prototype.Domain.Entities
{
    public class Address : Entity<long>, IAddress
    {
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }
        public string ThirdLine { get; set; }
        public string FourthLine { get; set; }
        public string City { get; set; }
        public long CountryId { get; set; }
        public Country Country { get; set; }
        public string PostalCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}

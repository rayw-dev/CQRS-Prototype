﻿using CQRS.Prototype.Country.Domain.Extensions;
using CQRS.Prototype.Country.Domain.Interfaces;

namespace CQRS.Prototype.Country.Domain.Models
{
    public class Country : ICountry
    {
        public long Id { get; set; }
        public string EnglishName { get; set; }
        public string LocalName { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public int NumericCode { get; set; }
        public bool Independant { get; set; }

        public Country()
        {

        }
        public Country(ICountry country)
        {
            this.Merge(country);
        }
    }
}

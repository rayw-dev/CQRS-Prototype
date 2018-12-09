﻿using CQRS.Prototype.Country.Domain.Interfaces;

namespace CQRS.Prototype.Country.Domain.Extensions
{
    public static class CountryExtensions
    {
        public static void Merge(this ICountry to, ICountry from)
        {
            to.Id = from.Id;
            to.EnglishName = from.EnglishName;
            to.LocalName = from.LocalName;
            to.Alpha2Code = from.Alpha2Code;
            to.Alpha3Code = from.Alpha3Code;
            to.NumericCode = from.NumericCode;
            to.Independant = from.Independant;
        }
    }
}

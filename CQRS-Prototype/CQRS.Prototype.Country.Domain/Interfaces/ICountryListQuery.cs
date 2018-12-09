namespace CQRS.Prototype.Country.Domain.Interfaces
{
    public interface ICountryListQuery
    {
        int CurrentPage { get; set; }
        int PageSize { get; set; }
        string NameFilter { get; set; }
        string Alpha3Filter { get; set; }
    }
}

namespace CQRS.Prototype.Address.Domain.Interfaces
{
    public interface IAddress
    {
        long Id { get; set; }
        string FirstLine { get; set; }
        string SecondLine { get; set; }
        string ThirdLine { get; set; }
        string FourthLine { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string PostalCode { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
    }
}


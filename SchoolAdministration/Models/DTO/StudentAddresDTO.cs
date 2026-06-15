using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.DTO
{
    public class StudentAddressDTO
    {
        public int Id { get; set; }
        public  bool IsMainAddress { get; set; }
        public int AddressOrder { get; set; }
        public required string StreetAndNumber { get; set; }
        public string? BusNumber { get; set; }
        public int Zipcode { get; set; }
        public string? City { get; set; }
        public string? CountryCode { get; set; }

    }
}

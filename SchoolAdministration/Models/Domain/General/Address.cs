using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.General
{
    public class Address
    {
      public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Street and number cannot be longer than 50 characters")]
        public required string StreetAndNumber { get; set; }

        public string? BusNumber { get; set; }


        [RegularExpression(@"^([0-9]{4})$", ErrorMessage = "Belgium zipcode must be 4 digits long.")]
        public int Zipcode { get; set; }
     
       
        [StringLength(30, ErrorMessage = "City cannot be longer than 50 characters")]
        public string? City { get; set; }
 
        [StringLength(3, ErrorMessage = "Country code cannot be longer than 3 characters")]
        public string? CountryCode { get; set; }
    
    }
}

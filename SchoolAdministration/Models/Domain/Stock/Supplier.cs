using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Stock
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public required string SupplierName { get; set; }
        public string? ContactPerson { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Stock
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public required string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int SupplierId { get; set; }
        public required Supplier Supplier { get; set; }
        public required ICollection<OrderItem> OrderItems { get; set; }
    }
}

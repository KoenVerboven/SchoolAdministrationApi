using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Stock
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public int Quantity { get; set; }
    }
}

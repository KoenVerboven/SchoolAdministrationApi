using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Stock
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public required string ArticleName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int MinimumStock { get; set; }
        public int CategoryId { get; set; }

        //todo : stock movements
        //todo : stock place   
    }
}

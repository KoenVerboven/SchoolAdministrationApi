using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Invoice
{
    public class InvoiceDetailLine
    {
        [Key]
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ArticleId { get; set; } 
        public int CourseId { get; set; }
        public int NumberOfArticles { get; set; } //Todoe : rename to NumberOfItems ??
        public int NumberOfCourses { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}

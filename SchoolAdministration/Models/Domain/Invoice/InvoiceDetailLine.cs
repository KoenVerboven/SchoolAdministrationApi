using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Invoice
{
    public class InvoiceDetailLine
    {
        [Key]
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int UnitId { get; set; } 
        public int UnitCount { get; set; }
        public string Description { get; set; } = string.Empty;

        [Microsoft.EntityFrameworkCore.Precision(18,4)]
        public decimal UnitPrice { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Invoice
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public required string InvoiceNumber { get; set; }
        public int StudentId { get; set; }
        public Decimal TotalAmount { get; set; }
        public ICollection<InvoiceDetailLine>? InvoiceDetailLines { get; set; }
    }
}

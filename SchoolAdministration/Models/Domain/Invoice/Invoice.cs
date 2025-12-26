using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Invoice
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public required string InvoiceNumber { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Decimal TotalAmount { get; set; }
        public required ICollection<InvoiceDetailLine> invoiceDetailLines { get; set; }
    }
}

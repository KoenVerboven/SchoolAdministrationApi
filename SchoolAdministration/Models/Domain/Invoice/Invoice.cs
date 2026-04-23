using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAdministration.Models.Domain.Invoice
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public required string InvoiceNumber { get; set; }
        public int StudentId { get; set; }
        
        [Column(TypeName = "money")]
        public Decimal TotalAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateOnly DueDate { get; set; }

        public ICollection<InvoiceDetailLine>? InvoiceDetailLines { get; set; }
    }
}

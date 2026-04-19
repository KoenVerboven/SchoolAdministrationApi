using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAdministration.Models.Domain.Invoice
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? InvoiceId { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public byte PaymentMethodId { get; set; } // todo cash, kreditcard, ...
        public int? TransactionId { get; set; }
    }
}

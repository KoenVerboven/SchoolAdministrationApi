
namespace SchoolAdministration.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // ToDo cash, kreditcart, ...
        public DateTime TransactionTime { get; set; }
    }
}

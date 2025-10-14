namespace SchoolAdministration.Models.Domain
{
    public class Payment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? ArticleId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentMethodId { get; set; } // todo cash, kreditcard, ...
        public int? TransactionId { get; set; }
    }
}

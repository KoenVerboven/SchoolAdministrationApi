namespace SchoolAdministration.Models.Domain.Communication
{
    public class MessagesHistory
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public int RecipientId { get; set; }
        public DateTime SentAt { get; set; }
    }
}

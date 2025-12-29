using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Communication
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Message Title is required.")]
        public required string Title { get; set; }
        public string? Content { get; set; }
        public byte MessageType { get; set; } //see MessageType enum
        public byte MessageWeight { get; set; } //see MessageWeight enum
        public DateTime SentAt { get; set; }
        public int SenderId { get; set; }
        public required int[] ReceiverIds { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Communication
{
    // todo :
    //Bussiness rules propsal:
    //a parent or student can only send messages to teacher in the time range of 8:00 AM to 6:00 PM, to ensure that teachers are not disturbed during their off hours and can maintain a healthy work-life balance.
    //a teacher can alltimes send messages to parents and students, to ensure that teachers can communicate important information to parents and students in a timely manner, regardless of the time of day.
    //Add Documents
    //Remark :you can only send messages to peopele who are know in the database.
    //Enscripted messages ?!

    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Message Title is required.")]
        public required string Title { get; set; }
        public string? Content { get; set; }
        public byte MessageType { get; set; } //see MessageType enum
        public byte MessageWeight { get; set; } //see MessageWeight enum
        public bool IsRead { get; set; }
        public DateTime SentAt { get; set; }
        public int SenderId { get; set; }
        public required int[] ReceiverId { get; set; }
        public required int[] Cc { get; set; }
        public required int[] Bcc { get; set; }
        public DateTime MinStartTimeToSendMessage { get; set; }
        public DateTime MaxStartTimeToSendMessage { get; set; }
    }
}

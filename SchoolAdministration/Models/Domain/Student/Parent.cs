using SchoolAdministration.Models.Domain.General;

namespace SchoolAdministration.Models.Domain.Student
{
    public class Parent : Person
    {
        public int SortOrder { get; set; } //most import : 1
        public int RelationShipToStudent { get; set; } //todo int to byte
        public string? Occupation { get; set; }
        public string? WorkPhoneNumber { get; set; }
        public string? WorkEmail { get; set; }
        public bool IsPrimaryContact { get; set; }
        public bool ReceivesInvoices { get; set; }
        public bool ReceivesReports { get; set; }
        public bool ReceivesMailings { get; set; }
        public bool ReceivesSms { get; set; }
        public string? Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Student>? Students { get; set; }

    }
}

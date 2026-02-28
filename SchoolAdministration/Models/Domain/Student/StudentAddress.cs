using Microsoft.EntityFrameworkCore;

namespace SchoolAdministration.Models.Domain.Student
{
    [PrimaryKey(nameof(StudentId), nameof(AddressId))]
    public class StudentAddress
    {
        public int StudentId { get; set; }
        public int AddressId { get; set; }
        public int AddressOrder { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegisteredByUserId { get; set; }
    }
}

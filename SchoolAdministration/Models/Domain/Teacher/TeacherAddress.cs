using Microsoft.EntityFrameworkCore;

namespace SchoolAdministration.Models.Domain.Teacher
{
    [PrimaryKey(nameof(TeacherId), nameof(AddressId))]
    public class TeacherAddress
    {
        public int TeacherId { get; set; }
        public int AddressId { get; set; }
        public int AddressOrder { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegisteredByUserId { get; set; }
    }
}

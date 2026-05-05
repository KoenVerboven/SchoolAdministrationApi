using SchoolAdministration.Models.Domain.General;
using SchoolAdministration.Models.Domain.School;
using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Teacher
{
    public class Teacher : Person
    {
        public DateTime HireDate { get; set; }

        public DateTime? LeaveDate { get; set; }

        [Display(Name = "Marital status")]
        public byte MaritalStatusId { get; set; }

        public ICollection<TeacherAddress>? TeacherAddresses { get; set; }
        public ICollection<TeacherPresence>? TeacherPresences { get; set; }
        public ICollection<SchoolClass>? SchoolClasses { get; set; }
    
        //todo leraar geeft volgend lessen + create date + updatedate + createdby + updatedby

    }
}

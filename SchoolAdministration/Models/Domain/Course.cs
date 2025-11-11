using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAdministration.Models.Domain
{
    public class Course
    {
        [Key]
        public  int Id { get; set; }

        [Required(ErrorMessage = "Course Name is required.")]
        [StringLength(30, ErrorMessage = "Course code cannot longer than 30 characters")]
        public required string CourseName { get; set; }

        [StringLength(5, ErrorMessage = "Course code cannot longer than 5 characters")]
        public string? CourseCode { get; set; }

        [StringLength(400, ErrorMessage = "Course description cannot longer than 400 characters")]
        public string? CourseDescription { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }// todo: make sure end date is after start date

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0, 99999.99, ErrorMessage = "Course price must be between 0 and 99999.99")]
        public decimal?  CoursePrice { get; set; }
        [Range(1, 10000, ErrorMessage = "Max number of students must be between 1 and 10000")]
        public int MaxNumberOfStudents { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<StudentPresence>? StudentPresences { get; set; }

    }

}

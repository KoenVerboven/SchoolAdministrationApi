
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAdministration.Models
{
    public class Course
    {
        //public Course()
        //{
        //    this.Students = new HashSet<Student>();
        //}

        [Key]
        public  int Id { get; set; }

        [Required(ErrorMessage = "Course Name is required.")]
        [StringLength(30, ErrorMessage = "Course code cannot longer than 30 characters")]
        public  string CourseName { get; set; }

        [StringLength(5, ErrorMessage = "Course code cannot longer than 5 characters")]
        public string? CourseCode { get; set; }

        [StringLength(50, ErrorMessage = "Course code cannot longer than 50 characters")]
        public string? CourseDescription { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal?  CoursePrice { get; set; }

        //public virtual ICollection<Student> Students { get; set; }

        //todo hoeveel leerlingen maximaal
        //todo hoeveel leerlingen minimaal

        //todo minimum aantal studies om aan deze cursus te mogen beginnen

        //todo welke leeraar?

        //todo online cursus of ter plaatse

        //todo totaal punten te behalen

        //todo examendate(s) (testdate)

        //todo oefeningen (excercise) vs proefwerk (test)

    }

}

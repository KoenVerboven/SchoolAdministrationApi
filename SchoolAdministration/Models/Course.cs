﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAdministration.Models
{
    public class Course
    {
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
 
    }

}

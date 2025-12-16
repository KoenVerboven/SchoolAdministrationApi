using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.School
{
    public class ClassRoom
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public int Name { get; set; }
        public string? Description { get; set; }
        public int SchoolId { get; set; }//FK
        public int BuildingId { get; set; }//FK
        public byte Floor { get; set; }
        public int StudentCapacity { get; set; }
        public string? Remarks { get; set; }

    }
}

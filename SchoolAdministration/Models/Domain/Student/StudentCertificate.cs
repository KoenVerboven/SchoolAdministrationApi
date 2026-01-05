using SchoolAdministration.Models.Domain.Qualification;
using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Student
{
    public class StudentCertificate
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CertificationId { get; set; }
        public DateTime CertificationDate { get; set; }
        public double? CertificateScore { get; set; }


        public required Student Student { get; set; } 
        public required Certificate Certificate { get; set; }
    }
}

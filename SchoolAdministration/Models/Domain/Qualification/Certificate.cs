using SchoolAdministration.Models.Domain.Document;

namespace SchoolAdministration.Models.Domain.Qualification
{
    public class Certificate
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}

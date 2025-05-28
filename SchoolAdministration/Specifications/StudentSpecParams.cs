namespace SchoolAdministration.Specifications
{
    public class StudentSpecParams
    {
        public string Sort { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string? Name { get; set; } // todo : place filter items in separately object
        public string? Email { get; set; }
        public int ZipCode { get; set; }
    }
}

using System.Net;

namespace SchoolAdministration.Models
{
    public class APIResponse
    {
        public HttpStatusCode Statuscode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}

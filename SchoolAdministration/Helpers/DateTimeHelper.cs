using SchoolAdministration.Models.Domain.Student;

namespace SchoolAdministration.Helpers
{
    public static class DateTimeHelper
    {
        public static int GiveDateInFormat_YYYYMMDD(DateTime date)
        {
            return int.Parse(date.ToString("yyyyMMdd"));
        }

        public static int CalculateAge(DateTime dateOfBirth)
        {
           return (int)(DateTime.Now - dateOfBirth).TotalDays / 365;


           
        }
    }
}

namespace SchoolAdministration.Helpers
{
    public static class StringHelper
    {
        public static string ChangeFirstCharFromNameToUpperCase(string name)       
        {
            return char.ToUpper(name[0]) + name[1..].ToLower().Trim();
        }

    }
}

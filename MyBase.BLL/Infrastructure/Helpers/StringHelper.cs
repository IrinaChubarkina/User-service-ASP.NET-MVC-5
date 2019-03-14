namespace MyBase.BLL.Infrastructure.Helpers
{
    public static class StringHelper
    {
        public static bool IsEmpty(this string value)
        {
            if (value == null || value.Length == 0)
            {
                return true;
            }
            return false;
        }
    }
}

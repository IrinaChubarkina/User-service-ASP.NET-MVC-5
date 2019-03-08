namespace MyBase.BLL.Infrastructure
{
    public class ConfigurationManager
    {
        public static string ConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;            
        }
    }
}

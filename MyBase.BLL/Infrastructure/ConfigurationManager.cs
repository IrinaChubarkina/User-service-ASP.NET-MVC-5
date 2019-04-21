using ConfigManager = System.Configuration.ConfigurationManager;

namespace MyBase.BLL.Infrastructure
{
    public class ConfigurationManager
    {
        public static string ConnectionString()
        {
            return ConfigManager.ConnectionStrings["DefaultConnection"].ConnectionString;            
        }
    }
}

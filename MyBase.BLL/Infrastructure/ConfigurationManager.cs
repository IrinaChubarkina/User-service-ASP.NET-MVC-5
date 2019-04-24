using ConfigManager = System.Configuration.ConfigurationManager;

namespace MyBase.BLL.Infrastructure
{
    public static class ConfigurationManager
    {
        public static string ConnectionString()
        {
            return ConfigManager.ConnectionStrings["DefaultConnection"].ConnectionString;            
        }
    }
}

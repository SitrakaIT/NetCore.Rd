using Microsoft.Extensions.Configuration;

namespace NetCore.Rd.Helpers.Settings
{
    public class AppConfig
    {
        public static IConfigurationRoot _configJson = Configuration.ConfigurationInfo;
        public static readonly string ConnectionString = _configJson.GetConnectionString("DefaultConnection");
    }
}
using System.IO;
using Microsoft.Extensions.Configuration;

namespace NetCore.Rd.Helpers.Settings
{
    public class Configuration
    {
        public static IConfigurationRoot ConfigurationInfo
        {
            get
            {
                ConfigurationBuilder build = new ConfigurationBuilder();
                return build.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false)
                    .Build();
            }
        }
    }
}
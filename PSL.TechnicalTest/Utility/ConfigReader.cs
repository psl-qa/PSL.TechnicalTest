

namespace PSL.TechnicalTest.Utility
{
    public class ConfigReader
    {
 
            private IConfigurationRoot _config;
            public ConfigReader()
            {
                var builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("settings.json");
                _config = builder.Build();
            }

            public string GetData(string key) => _config[key];
        
    }
}

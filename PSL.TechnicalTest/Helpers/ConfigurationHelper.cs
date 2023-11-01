
using Microsoft.Extensions.Configuration;
using PSL.TechnicalTest.Constants;


namespace PSL.TechnicalTest.Helpers
{
    public class ConfigurationHelper
    {

        public ConfigurationHelper(IConfiguration _Config)
        {
            RunConfiguration = new RunConfiguration
            { RunLocation = Environment.GetEnvironmentVariable(EnvironmentVariableKeys.TestPipeline) };
        }


        public RunConfiguration RunConfiguration { get; }


    }
}

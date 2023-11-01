using BoDi;
using Microsoft.Extensions.Configuration;
using PSL.TechnicalTest.ApplicationUnderTest.Pages;
using PSL.TechnicalTest.Constants;
using PSL.TechnicalTest.Helpers;
using PSL.TechnicalTest.Utilities;
using TechTalk.SpecFlow.TestFramework;

namespace PSL.TechnicalTest.Hooks
{
    [Binding]
    public class BeforeBindingHooks
    {
        #region Element Identifiers
        private readonly SeleniumContext _seleniumContext;
        public static IConfiguration _Config;
        private readonly IObjectContainer _objectContainer;
        private readonly ITestRunContext _testRunContext;
        private readonly FeatureContext _featureContext;
        private readonly IWebDriver _driver;

        #endregion
        public BeforeBindingHooks(IObjectContainer objectContainer, SeleniumContext seleniumContext,
           FeatureContext featureContext,
           ITestRunContext testRunContext)
        {
            _objectContainer = objectContainer;
            _seleniumContext = seleniumContext;
            _featureContext = featureContext;
            _testRunContext = testRunContext;
        }

        public void BindPages()
        {
            var basePage = new BasePage(_seleniumContext.WebDriver);
            var amazonHomePage = new AmazonHomePage(_seleniumContext.WebDriver);
            _objectContainer.RegisterInstanceAs(basePage);
            _objectContainer.RegisterInstanceAs(amazonHomePage);
        }

        [BeforeScenario(Order = 0)]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            CheckAndOverwriteEnvironmentVariables();
            var configurationHelper = BindConfig();
            BindPages();

        }
        private ConfigurationHelper BindConfig()
        {
            var environment = Environment.GetEnvironmentVariable(EnvironmentVariableKeys.TestEnvironment);
            string appsettingsPath = environment == null ? "appsettings.json" : $"appsettings.{environment}.json";

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            configurationBuilder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .SetBasePath(_testRunContext.GetTestDirectory())
                .AddJsonFile(appsettingsPath);

            _Config = configurationBuilder.Build();

            ConfigurationHelper configurationHelper = new(_Config);                      

            _objectContainer.RegisterInstanceAs(_Config);
            _objectContainer.RegisterInstanceAs(configurationHelper);

            return configurationHelper;
        }

        private void CheckAndOverwriteEnvironmentVariables()
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(EnvironmentVariableKeys.TestEnvironment)))
            {
                Environment.SetEnvironmentVariable(EnvironmentVariableKeys.TestEnvironment, EnvironmentVariableValues.Amazon);
            }
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            _seleniumContext.WebDriver.Quit();
        }
    }
}

using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using BoDi;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace PSL.TechnicalTest.Hooks
{
    [Binding]
    public class Hooks : DriverManager
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;

        public Hooks(ObjectContainer objectContainer, ScenarioContext scenarioContext, FeatureContext featureContext) : base(objectContainer)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            // Initialize WebDriver before each scenario, defaulting to Chrome.
            InitiateDriver(Constants.ChromeBrowser);
        }

        /// <summary>
        /// This method captures a screenshot on test failure.
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                if (_scenarioContext.TestError != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    Screenshot screenShot = ((ITakesScreenshot)Driver).GetScreenshot();
                    string title = _scenarioContext.ScenarioInfo.Title;
                    string screenShotName = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
                    Uri uri = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase);
                    string loadPath = Directory.GetParent(uri.LocalPath).FullName;
                    string screenShotDirectory = loadPath + "\\results\\screenshots\\";

                    if (!Directory.Exists(screenShotDirectory))
                    {
                        Directory.CreateDirectory(screenShotDirectory);
                    }

                    string screenShotFileName = screenShotDirectory + screenShotName + ".png";
                    screenShot.SaveAsFile(screenShotFileName);
                    string urlFile = Path.GetFullPath(screenShotFileName);
                    Console.WriteLine("Screenshot: {0}", new Uri(urlFile));

                    ReadOnlyCollection<LogEntry> logs = Driver.Manage().Logs.GetLog(LogType.Browser);
                    foreach (LogEntry log in logs)
                    {
                        stringBuilder.Append("\n" + log.Message);
                    }

                    TestContext.AddTestAttachment(urlFile, "ScreenShot");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // Clean up and quit the WebDriver instance.
                CleanUp();
            }
        }
    }
}


using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace PSL.TechnicalTest.Hooks
{
    public abstract class DriverManager
    {
        private readonly IObjectContainer _objectContainer;
        protected static IWebDriver Driver;

        protected DriverManager(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        // Initialize the WebDriver based on the provided browser type or use Chrome as the default.
        protected void InitiateDriver(string? browserType)
        {
            try
            {
                if (browserType != null)
                {
                    switch (browserType.ToUpper().Trim())
                    {
                        case "CHROME":
                            LoadChromeDriver();
                            break;

                        case "FIREFOX":
                            LoadFirefoxDriver();
                            break;

                        case "IE":
                            LoadIeDriver();
                            break;

                        default:
                            LoadChromeDriver();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Browser type is null, please send a valid browser name ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // Load the Chrome WebDriver instance.
        private void LoadChromeDriver()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--incognito");
            Driver = new ChromeDriver(chromeOptions);
            Driver.Manage().Cookies.DeleteAllCookies();
            _objectContainer.RegisterInstanceAs<IWebDriver>(Driver);
            Driver.Manage().Window.Maximize();
        }

        // Load the Firefox WebDriver instance.
        private void LoadFirefoxDriver()
        {
            Driver = new FirefoxDriver();
            Driver.Manage().Cookies.DeleteAllCookies();
            _objectContainer.RegisterInstanceAs<IWebDriver>(Driver);
            Driver.Manage().Window.Maximize();
        }

        // Load the Internet Explorer WebDriver instance.
        private void LoadIeDriver()
        {
            var driverService = InternetExplorerDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var options = new InternetExplorerOptions
            {
                RequireWindowFocus = false,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                IgnoreZoomLevel = true,
                EnableNativeEvents = false
            };

            Driver = new InternetExplorerDriver(driverService, options);
            _objectContainer.RegisterInstanceAs(Driver);
            Driver.Manage().Window.Maximize();
        }

        // Clean up and quit the WebDriver instance.
        protected void CleanUp()
        {
            Driver.Quit();
        }
    }
}


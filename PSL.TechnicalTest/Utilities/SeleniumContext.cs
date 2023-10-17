using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using PSL.TechnicalTest.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace PSL.TechnicalTest.Utilities
{
    [Binding]
    public class SeleniumContext
    {
        //private readonly FirefoxOptions _firefoxOptions = new FirefoxOptions();
        //private FirefoxDriverService _firefoxDriverService;

        public SeleniumContext()
        {
            WebDriver = GetTheWebDriverForTheBrowser();
            WebDriver.Manage().Window.Maximize();
        }

        private IWebDriver GetTheWebDriverForTheBrowser()
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(EnvironmentVariableKeys.Test_Browser)))
            {
                Environment.SetEnvironmentVariable(EnvironmentVariableKeys.Test_Browser, EnvironmentVariableValues.Chrome);
            }
            string browser = Environment.GetEnvironmentVariable("Test_Browser").ToLower();
            switch (browser)
            {
                case "chrome":
                    {
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments(new List<string>()
                    {
                        "--disable-gpu",
                        "--no-first-run",
                        "--no-default-browser-check",
                        "--ignore-certificate-errors",
                        "--no-sandbox",
                        //"--window-size=390,844",
                        "--window-size=1920,1200",
                        "--start-maximized",
                        "--disable-dev-shm-usage",
                         "--disable-infobars",
                        "--disable-extensions"
                    });
                        chromeOptions.AddExcludedArgument("enable-automation");
#if !DEBUG
                        chromeOptions.AddArguments("--headless");
#endif
                        var chromeconfig = new ChromeConfig();
                        var version = chromeconfig.GetLatestVersion();
                        var envChromeWebDriver = Environment.GetEnvironmentVariable("ChromeWebDriver");
                        if (string.IsNullOrEmpty(envChromeWebDriver))
                        {
                            new WebDriverManager.DriverManager().SetUpDriver(chromeconfig, version);
                            var driver = new ChromeDriver(chromeOptions);
                            driver.Manage().Cookies.DeleteAllCookies();
                            return driver;
                        }
                        else if (File.Exists(Path.Combine(envChromeWebDriver, "chromedriver.exe")))
                        {
                            chromeOptions.AddArguments($"window-size=1920,1200");
                            //chromeOptions.AddArguments($"window-size=390,844");

                            var driverPath = Path.Combine(envChromeWebDriver);
                            ChromeDriverService defaultService = ChromeDriverService.CreateDefaultService(driverPath);
                            defaultService.HideCommandPromptWindow = true;
                            var driver = new ChromeDriver(defaultService, chromeOptions);
                            driver.Manage().Cookies.DeleteAllCookies();
                            return driver;
                        }
                        else
                            throw new DriverServiceNotFoundException("Driver not installed: <null>");

                    }

                case "edge":
                    {
                        //Add Edge Browser config (In a real scenario for a framework + other browsers)

                        throw new DriverServiceNotFoundException("Driver not installed: <null>");
                    }
                default: throw new NotSupportedException("not supported browser: <null>");
            }
        }
        public IWebDriver WebDriver { get; set; }
    }
}

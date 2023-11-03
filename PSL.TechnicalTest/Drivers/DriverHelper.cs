namespace PSL.TechnicalTest.Drivers
{
    public class DriverHelper
    {
        public IObjectContainer container;
        public IWebDriver driver;
        ConfigReader configReader = new ConfigReader(); 
        public enum bType
        { Chrome, Firefox, Edge}
        public IWebDriver InitialliseBrowser(bType _browserName) => _browserName switch
        {
            bType.Chrome => driver = GetChromeConfig(),
            bType.Firefox => driver = GetFirefoxConfig(),
            bType.Edge => driver = GetEdgeConfig(),
            _=> throw new Exception ("Browser Not Found")
        };

        public IWebDriver GetChromeConfig()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            options.AddArguments(configReader.GetData("option:max"), configReader.GetData("option:incog"));
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(configReader.GetData("Env:url"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return driver;
        }
            public IWebDriver GetEdgeConfig()
            {
                new DriverManager().SetUpDriver(new EdgeConfig());
                driver = new EdgeDriver();
                driver.Manage().Window.Maximize();
                return driver;
            }

            public IWebDriver GetFirefoxConfig()
            {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                driver = new FirefoxDriver();
                driver.Manage().Window.Maximize();
                return driver;
            }

            public void QuitBrowser()
            {
                if (driver != null)
                {
                    driver.Quit();
                }
                driver = null;
            }
        }
    }


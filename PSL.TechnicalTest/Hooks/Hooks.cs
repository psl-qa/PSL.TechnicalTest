using OpenQA.Selenium.Chrome;
using static PSL.TechnicalTest.Support.DriverSetup;

namespace PSL.TechnicalTest.Hooks;

[Binding]
internal class Hooks
{

    [BeforeTestRun]
    public static void InitializeDriver()
    {
        var chromeDriver = ChromeDriverService.CreateDefaultService(Directory.GetCurrentDirectory());

        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("no-sandbox");
        chromeOptions.AddArgument("start-maximized");
        chromeOptions.AddArgument("ignore-certificate-errors");

        driver = new ChromeDriver(chromeDriver, chromeOptions);
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        driver.Dispose();
    }



}
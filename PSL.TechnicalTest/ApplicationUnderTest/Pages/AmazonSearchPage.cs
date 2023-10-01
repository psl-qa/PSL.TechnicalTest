using static PSL.TechnicalTest.Support.DriverSetup;

namespace PSL.TechnicalTest.ApplicationUnderTest.Pages
{
    public class AmazonSearchPage
    {
        public AmazonSearchPage(IWebDriver webDriver) { }        
        public IWebElement SearchItem => driver.FindElement(By.LinkText("SEGA Mega Drive Mini (Electronic Games)"));
    }
}

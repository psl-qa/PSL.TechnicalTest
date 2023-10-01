using PSL.TechnicalTest.ApplicationUnderTest.Pages;
using static PSL.TechnicalTest.Support.DriverSetup;

namespace PSL.TechnicalTest.Helpers
{
    internal class Utilities
    {
        private AmazonItemPage amazonItemPage = new AmazonItemPage(driver);

        public static bool IsElementPresent(IWebDriver driver, By locatorKey)
        {
            try
            {
                driver.FindElement(locatorKey);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public static  void RemoveCookiesPopUp(IWebDriver driver, By locatorKey)
        {

            if (IsElementPresent(driver, By.Id("sp-cc-rejectall-link")))
            {
               driver.FindElement(locatorKey).Click();
            }
            
        }
    }
}

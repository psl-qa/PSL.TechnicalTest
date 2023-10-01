using static PSL.TechnicalTest.Support.DriverSetup;

namespace PSL.TechnicalTest.ApplicationUnderTest.Pages
{
    public class AmazonItemPage
    {
        public AmazonItemPage(IWebDriver webDriver) { }

        public IWebElement AddItemToBasket => driver.FindElement(By.Id("add-to-cart-button"));
        public IWebElement RejectItemCover => driver.FindElement(By.Id("attachSiNoCoverage"));
        public IWebElement NotAcceptCookies => driver.FindElement(By.Id("sp-cc-rejectall-link"));
    }
}

using static PSL.TechnicalTest.Support.DriverSetup;

namespace PSL.TechnicalTest.ApplicationUnderTest.Pages
{
    internal class AmazonCartPage
    {
        public AmazonCartPage(IWebDriver webDriver) { }

        public IWebElement GoToBasket => driver.FindElement(By.Id("nav-cart"));
        public IWebElement ShoppingBasket => driver.FindElement(By.XPath("//*[@id=\"activeCartViewForm\"]/div[2]"));
        public IWebElement DeleteItem => driver.FindElement(By.CssSelector("span[data-action='sc-item-action'] input[data-action='delete']"));
        public IWebElement AllShoppingBasketContents => driver.FindElement(By.Id("sc-active-cart"));



    }
}

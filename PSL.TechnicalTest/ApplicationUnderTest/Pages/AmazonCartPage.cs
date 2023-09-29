using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PSL.TechnicalTest.Support.DriverSetup;

namespace PSL.TechnicalTest.ApplicationUnderTest.Pages
{
    internal class AmazonCartPage
    {
        public AmazonCartPage(IWebDriver webDriver) { }

        public IWebElement GoToBasket => driver.FindElement(By.Id("nav-cart"));

        public IWebElement ShoppingBasket => driver.FindElement(By.XPath("//*[@id=\"activeCartViewForm\"]/div[2]"));

    }
}

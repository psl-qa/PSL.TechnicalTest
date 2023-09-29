using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PSL.TechnicalTest.Support.DriverSetup;

namespace PSL.TechnicalTest.ApplicationUnderTest.Pages
{
    public class AmazonSearchPage
    {

        public AmazonSearchPage(IWebDriver webDriver) { }
        
        public IWebElement SearchItem => driver.FindElement(By.LinkText("SEGA Mega Drive Mini (Electronic Games)"));
    }
}

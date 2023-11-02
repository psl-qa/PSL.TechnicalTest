namespace PSL.TechnicalTest.ApplicationUnderTest.Pages
{
    public class SearchPage
    {
        private IWebDriver driver;
        private CustomMethod customMethod;
        public SearchPage(IObjectContainer _objectContainer)
        { 
            driver = _objectContainer.Resolve<IWebDriver>();
            customMethod = _objectContainer.Resolve<CustomMethod>();
        }

        private IWebElement searchTheBBcField => 
            customMethod.FindAndReturnElement(driver, By.XPath("//input[@name='q']"));

        private IWebElement searchBtn => 
            customMethod.FindAndReturnElement(driver, By.CssSelector("button[type='submit']"));

        public void EnterInfo(string text) => searchTheBBcField.SendKeys(text);
       
        public void ClickSearchBtn() => searchBtn.ClickElement();

        public bool IsSearchPageDisplayed() => searchTheBBcField.Displayed;
    }
}

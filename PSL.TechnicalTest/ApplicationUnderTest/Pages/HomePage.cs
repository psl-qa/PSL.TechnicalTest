namespace PSL.TechnicalTest.ApplicationUnderTest.Pages;
public class HomePage
{
    private IWebDriver driver;
    private CustomMethod customMethods;
   
    public HomePage(IObjectContainer _objectContainer) 
    {
        driver = _objectContainer.Resolve<IWebDriver>();
        customMethods = _objectContainer.Resolve<CustomMethod>();
    }

    private IWebElement yes => driver.FindElement(By.XPath("//span[contains(text(),'Yes, I agree')]"));
    private IWebElement searchField => customMethods.FindAndReturnElement(driver, By.CssSelector("#orbit-search-button"));

    public void AcceptCookies() => yes.Click();
    public void ClickSearchField() => searchField.ClickViaJavaScript(driver);
 
}

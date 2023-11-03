namespace PSL.TechnicalTest.CustomMethods
{
    public class CustomMethod
    {
        private Lazy<WebDriverWait> _wait = null!;

        private WebDriverWait GetWaitDriver(IWebDriver driver)
        {
            return new(driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromSeconds(1),
            };
        }

        public IWebElement FindAndReturnElement(IWebDriver driver, By locator)
        {
            _wait = new Lazy<WebDriverWait>(GetWaitDriver(driver));
            return _wait.Value.Until(x=>x.FindElement(locator));
        }
    }
}

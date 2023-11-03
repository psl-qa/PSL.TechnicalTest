namespace PSL.TechnicalTest.Extension
{
    public static class Extensions
    {
        /// <summary>
        /// This Method Clicks an Element
        /// </summary>
        /// <param name="element"></param>
        public static void ClickElement(this IWebElement element) => element.Click();

        /// <summary>
        /// This Method Clicks an Element using IJavaScript
        /// </summary>
     
        public static IJavaScriptExecutor ClickViaJavaScript(this IWebElement element, IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);
            return js;
        }

        public static IWebElement FindMyElementWait(this IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return wait.Until(x => x.FindElement(locator));
        }
    }
}

using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PSL.TechnicalTest.Hooks
{
    public class BaseClass
    {
        private readonly IWebDriver _driver;
        public readonly WebDriverWait Wait;

        public BaseClass(IWebDriver driver)
        {
            _driver = driver;
            Wait = new WebDriverWait(this._driver, TimeSpan.FromSeconds(Constants.Timeout));
        }

        // Navigate to a given page URL
        public void NavigateToPage(string pageUrl)
        {
            _driver.Navigate().GoToUrl(pageUrl);
        }

        // Wait for the page to load
        public void WaitForPageToLoad()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Constants.PageLoadTimeout);
        }

        // Click an element by its locator
        public void ClickEvent(By locator, bool skipHighlight = false)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            SetHighlight(locator, skipHighlight);
            _driver.FindElement(locator).Click();
        }

        // Enter text into an input field by its locator
        public void EnterText(By locator, string? text)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            SetHighlight(locator);
            _driver.FindElement(locator).Clear();
            _driver.FindElement(locator).SendKeys(text?.Trim());
        }

        // Select an option by text from a dropdown or select input
        public void SelectByText(By locator, string? text)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            SetHighlight(locator);
            _driver.FindElement(locator).Clear();
            _driver.FindElement(locator).SendKeys(text?.Trim());
        }

        // Get an element by its locator
        public IWebElement? GetElement(By locator)
        {
            IWebElement? element = null;
            try
            {
                element = _driver.FindElement(locator);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return element;
        }

        public IReadOnlyCollection<IWebElement>? GetElements(By locator)
        {
            IReadOnlyCollection<IWebElement>? element = null;
            try
            {
                element = _driver.FindElements(locator);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return element;
        }

        // Get the current URL of the page
        public string GetCurrentUrl()
        {
            return _driver.Url;
        }

        // Scroll to view an element by its locator
        public void ScrollToView(By locator)
        {
            _driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", _driver.FindElement(locator));
        }

        // Check if an element is visible
        public bool ElementIsVisible(By locator)
        {
            try
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
                SetHighlight(locator);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        // Get the text of an element by its locator
        public string? GetElementText(By locator)
        {
            IWebElement? element = null;
            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(locator));
                SetHighlight(locator);
                element = _driver.FindElement(locator);
                return element.Text;
            }
            catch (ElementNotVisibleException)
            {
                return null;
            }
        }

        // Get the text of an element by the element itself
        public string? GetElementText(IWebElement element)
        {
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                return element.Text;
            }
            catch (ElementNotVisibleException)
            {
                return null;
            }
        }

        // Set a highlight on an element to visually identify it (optional)
        public void SetHighlight(By locator, bool skipHighlight = false)
        {
            if (!skipHighlight)
            {
                string attributeValue = "border: 3px solid blue;";
                IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
                try
                {
                    Wait.Until(ExpectedConditions.ElementIsVisible(locator));
                    IWebElement? element = GetElement(locator);
                    executor.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, attributeValue);
                }
                catch (ThreadInterruptedException)
                {
                    Console.WriteLine("Exception");
                }
            }
        }
    }
}

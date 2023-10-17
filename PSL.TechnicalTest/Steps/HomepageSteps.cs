using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSL.TechnicalTest.ApplicationUnderTest.Pages;
using PSL.TechnicalTest.Constants;

namespace PSL.TechnicalTest.Steps
{
    [Binding]
    public class HomepageSteps
    {
        #region Locators
        public readonly AmazonHomePage _homePage;

        #endregion

        public HomepageSteps(AmazonHomePage homePage)
        {
            _homePage = homePage;
        }

        [Given(@"the user navigates to the homepage")]
        public void GivenTheUserNavigatesToTheHomepage()
        {
            _homePage.GoToTheApp("https://www.amazon.co.uk/");
            _homePage.WaitForTimeOut();
            var amazonBotDetector = By.XPath("//h4[text() = 'Type the characters you see in this image:']");
            if (_homePage.IsElementDisplayed(amazonBotDetector))
            {
                _homePage.BrowserQuit();
                throw new Exception("Unable to pass Amazon Bot Detector");
            }
        }

        [Given(@"the user searches a razor and clicks a product")]
        public void GivenTheSearchesARazorAndClicksAProduct()
        {
            _homePage.SearchForAnItem("Razor");
            _homePage.SelectItemFromSearchResults();
        }

        [When(@"the user adds the item to the basket")]
        public void WhenTheUserAddsTheItemToTheBasket()
        {
            using (new AssertionScope())
            {
                Assert.IsTrue(_homePage.ProductTitleMatch());
            }
            _homePage.AddToBasket();
        }

        [Then(@"the item is successfully added to the basket")]
        public void ThenTheItemIsSuccessfullyAddedToTheBasket()
        {
            using (new AssertionScope())
            {
                Assert.IsTrue(_homePage.ItemAddedToBasketSuccessfully());
            }
        }


    }

}
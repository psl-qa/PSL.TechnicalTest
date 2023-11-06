using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSL.TechnicalTest.Hooks;
using System.Linq;

namespace PSL.TechnicalTest.ApplicationUnderTest.Pages
{
    public class SearchPage : BaseClass
    {
        
        public SearchPage(IWebDriver driver) : base(driver)
        {

        }

        private By SearchTermLocator => By.Id("searchInput");
        private By SearchButton => By.Id("searchButton");
        private By SearchResults => By.XPath("//div[contains(@data-testid,'default-promo')]");



        public void EnterSearchTerm(string searchTerm)
        {
            EnterText(SearchTermLocator,searchTerm);
        }

        public void ClickOnSearch()
        {
            ClickEvent(SearchButton, skipHighlight: true);
        }

        public void VerifySearchResults(string searchTerm)
        {
            string? actualSearchResultsText = GetElementText(SearchResults);
            if (actualSearchResultsText != null)
            {
                Assert.IsTrue(actualSearchResultsText.Contains(searchTerm), "The search results do not show the expected search term");
            }
            else
            {
                Console.WriteLine("Exception");
            }
        }

        public void VerifyFirstFiveSearchResults(string searchTerm)
        {

            foreach (IWebElement ele in GetElements(SearchResults))
            {
                string? actualSearchResultsText = ele.Text;
                int actualSearchResultsCount = GetElements(SearchResults).Count;
                for (int i = 0; i < actualSearchResultsCount; i++)
                {

                    if (actualSearchResultsText != null)
                    {
                        Assert.IsTrue(actualSearchResultsText.Contains(searchTerm), "The search results do not show the expected search term");
                    }
                    else
                    {
                        Console.WriteLine("Exception");
                    }
                }
            }
            
        }
    }
}

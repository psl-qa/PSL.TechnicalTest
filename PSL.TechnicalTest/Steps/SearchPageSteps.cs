using PSL.TechnicalTest.ApplicationUnderTest.Pages;


namespace PSL.TechnicalTest.Steps
{
    [Binding]
    public class SearchPageSteps : BasePage
    {
        public SearchPageSteps(IWebDriver driver) : base(driver)
        {
        }

        [When(@"the user enters search term as (.*)")]
        public void WhenTheUserEntersSearchTermAs(string searchTerm)
        {
            SearchPage.EnterSearchTerm(searchTerm);
        }

        [When(@"click on search button")]
        public void WhenClickOnSearchButton()
        {
            SearchPage.ClickOnSearch();
        }

        [Then(@"the user can see search results related to (.*)")]
        public void ThenTheUserCanSeeSearchResultsRelatedTo(string searchTerm)
        {
            SearchPage.VerifySearchResults(searchTerm);
        }

        [Then(@"the user can verify results related to (.*) on the search page")]
        public void ThenTheUserCanVerifyResultsRelatedToOnTheSearchPage(string searchTerm)
        {
            SearchPage.VerifyFirstFiveSearchResults(searchTerm);
        }

    }
}

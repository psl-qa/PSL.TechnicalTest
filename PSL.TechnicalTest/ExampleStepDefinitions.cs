namespace PSL.TechnicalTest
{
    [Binding]
    public class ExampleStepDefinitions
    {
        private IWebDriver driver;
        private HomePage homePage;
        private SearchPage searchPage;
        ConfigReader configReader = new ConfigReader();

        public ExampleStepDefinitions(IObjectContainer _objectContainer)
        { 
            driver = _objectContainer.Resolve<IWebDriver>();
            homePage = _objectContainer.Resolve<HomePage>();
            searchPage = _objectContainer.Resolve<SearchPage>();
        }

        [Given(@"I Navigate to bbc homepage")]
        public void GivenINavigateToBbcHomepage()
        {
            Assert.IsTrue(driver.Url.Contains("bbc"));
        }

        [Given(@"I click on searchField")]
        public void GivenIClickOnSearchField()
        {
            homePage.AcceptCookies();
            homePage.ClickSearchField();
        }

        [Then(@"I should be on the SearchPAge")]
        public void ThenIShouldBeOnTheSearchPAge()
        {
            Assert.IsTrue(searchPage.IsSearchPageDisplayed());
        }

        [When(@"I enter Chorley in the searchfiled and click search")]
        public void WhenIEnterChorleyInTheSearchfiledAndClickSearch()
        {
            searchPage.EnterInfo(configReader.GetData("mySearch:Text"));
            searchPage.ClickSearchBtn();
        }

        [Then(@"the top five results contain '([^']*)' in the title")]
        public void ThenTheTopFiveResultsContainInTheTitle(string chorley)
        {
            int count = 0;
            ReadOnlyCollection<IWebElement> allSearch = driver.FindElements(By.CssSelector("p[class='ssrcss-6arcww-PromoHeadline exn3ah96'] span"));

            if (allSearch.Count > 0)
            {
                allSearch.ToList().ForEach(x =>
                {
                    if(count <= 4)
                    {
                        Assert.IsTrue(x.Text.Contains(chorley));
                        count++;
                    }
                });
            }
        }  
    }
}

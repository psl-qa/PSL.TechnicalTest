using PSL.TechnicalTest.ApplicationUnderTest.Pages;


namespace PSL.TechnicalTest.Steps
{
    [Binding]
    public class HomePageSteps : BasePage
    {
        public HomePageSteps(IWebDriver driver) : base(driver)
        {

        }    

        [Given(@"the user is on bbc news website")]
        public void GivenTheUserIsOnBbcNewsWebsite()
        {
            HomePage.NavigateToUrl();
        }

        [When(@"the user click on search")]
        public void WhenTheUserClickOnSearch()
        {
            HomePage.ClickOnSearch();
        }        

    }
}

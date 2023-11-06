using PSL.TechnicalTest.Hooks;

namespace PSL.TechnicalTest.ApplicationUnderTest.Pages
{
    public class HomePage : BaseClass
    {

        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        private By SearchIcon => By.Id("orbit-search-button");
        private string url = "https://www.bbc.co.uk/news";

        public void NavigateToUrl()
        {
            NavigateToPage(url);
        }

        public void ClickOnSearch()
        {
            ClickEvent(SearchIcon, skipHighlight: true);
        }
    }
}

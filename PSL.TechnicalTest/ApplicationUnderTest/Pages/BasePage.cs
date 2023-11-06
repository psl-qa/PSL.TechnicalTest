namespace PSL.TechnicalTest.ApplicationUnderTest.Pages
{
    public class BasePage
    {
        // Declare instances of page objects.
        public HomePage HomePage;
        public SearchPage SearchPage;

        public BasePage(IWebDriver driver)
        {
            // Initialize page objects with the WebDriver instance.
            HomePage = new HomePage(driver); // Initialize the HomePage object.
            SearchPage = new SearchPage(driver); // Initialize the SearchPage object.
        }
    }
}
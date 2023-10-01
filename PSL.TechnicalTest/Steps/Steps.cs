using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using PSL.TechnicalTest.ApplicationUnderTest.Pages;
using SeleniumExtras.WaitHelpers;
using static PSL.TechnicalTest.Support.DriverSetup;
using static PSL.TechnicalTest.Helpers.Utilities;


namespace PSL.TechnicalTest.Steps;

[Binding]
internal class Steps
{
    private AmazonHomePage amazonHomePage = new AmazonHomePage(driver);
    private AmazonSearchPage amazonSearchPage = new AmazonSearchPage(driver);
    private AmazonItemPage amazonItemPage = new AmazonItemPage(driver);
    private AmazonCartPage amazonCartPage = new AmazonCartPage(driver);

    private WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

    [Given(@"I navigate to Amazon")]
    public void GivenINavigateToAmazon()
    {
        driver.Navigate().GoToUrl("https://www.amazon.co.uk");
    }   

    [When(@"I search for SEGA Mega Drive Mini \(Electronic Games\)")]
    public void WhenISearchForSEGAMegaDriveMiniElectronicGames()
    {
        amazonHomePage.SearchField.SendKeys("SEGA Mega Drive Mini (Electronic Games)");
        amazonHomePage.SubmitSearch.Click();
    }

    [When(@"I select the SEGA Mega Drive Mini \(Electronic Games\)")]
    public void WhenISelectTheSEGAMegaDriveMiniElectronicGames()
    {
        amazonSearchPage.SearchItem.Click();
    }

    [When(@"I choose to add  SEGA Mega Drive Mini to the basket")]
    public void WhenIChooseToAddSEGAMegaDriveMiniToTheBasket()
    {
        RemoveCookiesPopUp(driver, By.Id("sp-cc-rejectall-link"));
        
        amazonItemPage.AddItemToBasket.Click();
        wait.Until(ExpectedConditions.ElementToBeClickable(amazonItemPage.RejectItemCover));       
        amazonItemPage.RejectItemCover.Click();
    }

    [When(@"I search for ""([^""]*)""")]
    public void WhenISearchFor(string toys)
    {
        amazonHomePage.SearchField.SendKeys(toys);
        amazonHomePage.SubmitSearch.Click();
    }

    [When(@"I filter results with a maximum price of ""([^""]*)""")]
    public void WhenIFilterResultsWithAMaximumPriceOf(string maxPrice)
    {
        RemoveCookiesPopUp(driver, By.Id("sp-cc-rejectall-link"));
        amazonHomePage.MaxPriceFilter.SendKeys(maxPrice);        
        amazonHomePage.MaxPriceFilter.SendKeys(Keys.Enter);
    }


    [Then(@"SEGA Mega Drive Mini is added to the basket")]
    public void ThenSEGAMegaDriveMiniIsAddedToTheBasket()
    {

        //wait.Until(ExpectedConditions.ElementToBeClickable(amazonCartPage.GoToBasket));
        Thread.Sleep(1500);//Should not use this but unable to make it work in a more elegant way like the line comented above
        amazonCartPage.GoToBasket.Click();
        Assert.IsTrue(amazonCartPage.ShoppingBasket.Text.Contains("SEGA Mega Drive Mini (Electronic Games)"));
    }

    [Then(@"All the results returned have a maximum price of ""([^""]*)""")]
    public void ThenAllTheResultsReturnedHaveAMaximumPriceOf(string p0)
    {
        IList<IWebElement> searchResults = driver.FindElements(By.ClassName("a-price-whole"));

        foreach (var item in searchResults.Take(5))//Had to limit it to five elements as amazon randomly adds "exclusives" that do not match the filter value
        {       
            
            int itemPrice = int.Parse(item.Text);
            int expectedPrice = int.Parse(p0);
            // Use Fluent Assertions to assert that item's price is lower than expected price
            itemPrice.Should().BeLessThan(expectedPrice, $"because item price '{item.Text}' should be lower than '{p0}'");
        }       
    }

}

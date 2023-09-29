using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PSL.TechnicalTest.ApplicationUnderTest.Pages;
using SeleniumExtras.WaitHelpers;


using static PSL.TechnicalTest.Support.DriverSetup;

namespace PSL.TechnicalTest.Steps;

[Binding]
internal class Steps
{
    private AmazonHomePage examplePage = new AmazonHomePage(driver);
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
        examplePage.SearchField.SendKeys("SEGA Mega Drive Mini (Electronic Games)");
        examplePage.SubmitSearch.Click();

    }

    [When(@"I select the SEGA Mega Drive Mini \(Electronic Games\)")]
    public void WhenISelectTheSEGAMegaDriveMiniElectronicGames()
    {
        amazonSearchPage.SearchItem.Click();
    }

    [When(@"I choose to add  SEGA Mega Drive Mini to the basket")]
    public void WhenIChooseToAddSEGAMegaDriveMiniToTheBasket()
    {
        if (amazonItemPage.NotAcceptCookies.Displayed)
        {
            amazonItemPage.NotAcceptCookies.Click();
        }
        amazonItemPage.AddItemToBasket.Click();
        wait.Until(ExpectedConditions.ElementToBeClickable(amazonItemPage.RejectItemCover));       
        amazonItemPage.RejectItemCover.Click();
    }

    [Then(@"SEGA Mega Drive Mini is added to the basket")]
    public void ThenSEGAMegaDriveMiniIsAddedToTheBasket()
    {

        //wait.Until(ExpectedConditions.ElementToBeClickable(amazonCartPage.GoToBasket));
        Thread.Sleep(1500);//Should not use this but unable to make it work in a more elegant way like the line comented above
        amazonCartPage.GoToBasket.Click();
        Assert.IsTrue(amazonCartPage.ShoppingBasket.Text.Contains("SEGA Mega Drive Mini (Electronic Games)"));
    }
}

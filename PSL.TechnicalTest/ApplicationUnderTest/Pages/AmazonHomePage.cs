﻿namespace PSL.TechnicalTest.ApplicationUnderTest.Pages;
using static PSL.TechnicalTest.Support.DriverSetup;

public class AmazonHomePage
{
    public AmazonHomePage(IWebDriver webDriver) { }

    public IWebElement SearchField => driver.FindElement(By.Id("twotabsearchtextbox"));
    public IWebElement SubmitSearch => driver.FindElement(By.Id("nav-search-submit-button"));
}

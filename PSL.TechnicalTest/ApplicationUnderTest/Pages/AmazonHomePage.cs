using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PSL.TechnicalTest.ApplicationUnderTest.Pages
{
    [Binding]
    public class AmazonHomePage : BasePage
    {
        #region Elements
        private readonly IWebDriver _driver;
        private readonly By _schSearchBar = By.Id(TechTestResources.SearchTextBoxId);
        private readonly By _btnSearchBoxSubmit = By.Id(TechTestResources.SearchButtonSubmitId);
        private readonly By _btnAddToBasket = By.Id(TechTestResources.AddToBasketButtonId);
        private readonly By _msgAddedToBasketMessage = By.XPath("//span[@class='a-size-medium-plus a-color-base sw-atc-text a-text-bold']");
        public static string _ttlProductTitle;


        #endregion
        public AmazonHomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void SearchForAnItem(string textToSearch)
        {
            ClickOn(_schSearchBar);
            EnterText(_schSearchBar, textToSearch);
            ClickOn(_btnSearchBoxSubmit);
        }

        public void SelectItemFromSearchResults()
        {
            string xpath = "(//div[@class='a-section a-spacing-base'])";
            var count = _driver.FindElements(By.XPath(xpath)).Count();
            int rnd = new Random().Next(0, count);
            By product = By.XPath($"({xpath}+[{rnd}])//span[@class='a-size-base-plus a-color-base a-text-normal']");
            _ttlProductTitle = GetText(product);
            ClickOn(product);
        }

        public bool ProductTitleMatch()
        {
            //PDP Abbreviation = product display page
            var productTitle = GetText(By.Id(TechTestResources.PDPProductTitleId));
            if (productTitle == _ttlProductTitle)
            {
                return true;
            }
            else
            {
                throw new Exception("Product does not match that of selected");
            }
        }

        public void AddToBasket()
        {
            ClickOn(_btnAddToBasket);
        }

        public bool ItemAddedToBasketSuccessfully()
        {
            string text = GetText(_msgAddedToBasketMessage);
            if (text.Contains("Added to Basket"))
            {
                return true;
            }
            else
            {
                throw new Exception("Product does not match that of selected");
            }
        }
    }


}

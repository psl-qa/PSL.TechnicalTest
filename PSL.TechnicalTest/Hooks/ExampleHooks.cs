namespace PSL.TechnicalTest.Hooks;
[Binding]
public class ExampleHooks : DriverHelper
{
        public ExampleHooks(IObjectContainer _objectContainer)
        {
            container = _objectContainer;
        }

        [BeforeScenario()]
        public void FirstBeforeScenario()
        {
            InitialliseBrowser(bType.Chrome);
            container.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            QuitBrowser();
        }
}

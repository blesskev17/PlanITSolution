using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace PlanItTesting.Utilities
{
    [Binding]
    public class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        IWebDriver driver;

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            driver = new ChromeDriver();
            ScenarioContext.Current["Driver"] = driver;
        }



        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}

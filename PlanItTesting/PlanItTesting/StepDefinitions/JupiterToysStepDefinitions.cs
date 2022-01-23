using System;
using OpenQA.Selenium;
using PlanItTesting.AppLibraries;
using TechTalk.SpecFlow;

namespace PlanItTesting.StepDefinitions
{
    [Binding]
    public class JupiterToysStepDefinitions
    {
        IWebDriver driver = (IWebDriver)ScenarioContext.Current["Driver"];
        [Given(@"I launch JupitorToyUrl")]
        public void GivenILaunchJupitorToyUrl()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Constants.ConstantClass.url);
        }

        [Given(@"I click on contact")]
        public void GivenIClickOnContact()
        {
            HomePage hp = new HomePage(driver);
            hp.ClickContact();
        }

        [Given(@"I enter (.*) (.*) (.*) (.*) and (.*)")]
        public void GivenIEnterJohnHonaiJohn_HonaiExample_ComAndAddingContacts(string firstName, string surName, string email, string teleph, string message)
        {
            ContactPage cp = new ContactPage(driver);
            cp.enterFirstName(firstName);
            cp.enterSurName(surName);
            cp.enterEmail(email);
            cp.enterTelephone(teleph);
            cp.enterMessage(message);
        }

        [When(@"I click on submit button")]
        public void WhenIClickOnSubmitButton()
        {
            ContactPage cp = new ContactPage(driver);
            cp.clickSubmit();
        }

        [Then(@"verify the success message displayed")]
        public void ThenVerifyTheSuccessMessageDisplayed()
        {
            ContactPage cp = new ContactPage(driver);
            cp.verifySuccessMessage();
        }

        [Given(@"I click on Shop")]
        public void GivenIClickOnShop()
        {
            HomePage hp = new HomePage(driver);
            hp.ClickShop();
        }

        [Given(@"I click buy button on '([^']*)'")]
        public void GivenIClickBuyButtonOn(string item)
        {
            ShopPage sp = new ShopPage(driver);
            sp.ClickBuyButton(item);
        }

        [When(@"I click on cart")]
        public void WhenIClickOnCart()
        {
            ShopPage sp = new ShopPage(driver);
            sp.ClickCart();
        }

        [Then(@"I verify the items Funny Cow and Fluffy Bunny in cart")]
        public void ThenIVerifyTheItemsFunnyCowAndFluffyBunnyInCart()
        {
            ShopPage sp = new ShopPage(driver);
            sp.verifyItemsInCart(driver);
        }

        [Given(@"I click buy button on '([^']*)' for (.*) times")]
        public void GivenIClickBuyButtonOnForTimes(string itemName, int itemCount)
        {
            ShopPage sp = new ShopPage(driver);
            sp.ClickBuyButtonWithCount(itemName, itemCount);
        }

        [Then(@"I verify the Subtotal for each of the product")]
        public void ThenIVerifyTheSubtotalForEachOfTheProduct()
        {
            ShopPage sp = new ShopPage(driver);
            sp.VerifySubTotalEachProduct(driver);
        }
    }
}

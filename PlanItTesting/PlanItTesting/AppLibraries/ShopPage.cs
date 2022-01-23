using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PlanItTesting.Utilities;
using SeleniumExtras.PageObjects;
namespace PlanItTesting.AppLibraries
{
    public class ShopPage : PageObjectBase
    {

        [FindsBy(How = How.XPath, Using = "//*[@id='product-6']/div/p/a")]
        private IWebElement _btnBuyFunnyCow;

        [FindsBy(How = How.XPath, Using = "//*[@id='product-4']/div/p/a")]
        private IWebElement _btnBuyFluffyBunny;

        [FindsBy(How = How.XPath, Using = "//*[@id='product-2']/div/p/a")]
        private IWebElement _btnBuyStuffedFrog;

        [FindsBy(How = How.XPath, Using = "//*[@id='product-7']/div/p/a")]
        private IWebElement _btnBuyValentineBear;

        [FindsBy(How = How.XPath, Using = "//*[@id='nav-cart']/a")]
        private IWebElement _linkCart;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/form/table/tbody/tr")]
        private IList<IWebElement> allRows;


        IWebDriver driver;
        public ShopPage(IWebDriver driver) : base(driver)
        {

        }

        public void ClickBuyButton(string item)
        {
            try
            {
                if (item.Equals("Funny Cow"))
                {
                    if (_btnBuyFunnyCow.Displayed)
                        _btnBuyFunnyCow.Click();
                }
                else if (item.Equals("Fluffy Bunny"))
                {
                    if (_btnBuyFluffyBunny.Displayed)
                        _btnBuyFluffyBunny.Click();
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to click on buy button", ex);
            }

        }

        public void ClickCart()
        {
            try
            {
                if (_linkCart.Displayed)
                    _linkCart.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to click on cart link", ex);
            }
        }


        public void verifyItemsInCart(IWebDriver driver)
        {
            try
            {
                int num_rows = allRows.Count();
                for (int i = 1; i <= num_rows; i++)
                {


                    int countofCow = driver.FindElements(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[i]/td[1]/img[contains(@src,'cow')]")).Count();
                    int countofBunny = driver.FindElements(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[i]/td[1]/img[contains(@src,'bunny')]")).Count();
                    if (countofCow > 0)
                    {
                        Console.WriteLine("Funny Cows are added in cart");
                    }
                    else if (countofBunny > 0)
                    {
                        Console.WriteLine("Funny Cows are added in cart");
                    }


                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Items are not added in cart");
            }
        }

        public void ClickBuyButtonWithCount(string itemName, int itemCount)
        {
            //  IWebDriver wait = new WebDriverWait(driver,3);
            if (itemName.Equals("Stuffed Frog"))
            {
                for (int i = 0; i < itemCount; i++)
                {
                    _btnBuyStuffedFrog.Click();
                }


            }
            else if (itemName.Equals("Fluffy Bunny"))
            {
                for (int i = 0; i < itemCount; i++)
                {
                    _btnBuyFluffyBunny.Click();
                }
            }
            else if (itemName.Equals("Valentine Bear"))
            {
                for (int i = 0; i < itemCount; i++)
                {
                    _btnBuyValentineBear.Click();
                }
            }
        }

        public void VerifySubTotalEachProduct(IWebDriver driver)
        {
            try
            {
                bool isEqual = true;
                int num_rows = allRows.Count();
                string priceValueWithDollar, subTotalwithDollar;
                decimal priceValue, quantity, number;
                // int columnCount;

                for (int j = 1; j <= num_rows; j++)
                {

                    priceValueWithDollar = driver.FindElement(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[" + j + "]/td[2]")).Text;
                    subTotalwithDollar = driver.FindElement(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[" + j + "]/td[4]")).Text;
                    decimal subTotal = decimal.Parse(subTotalwithDollar.Substring(1));
                    string quantElement = driver.FindElement(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[" + j + "]/td[3]/input")).GetAttribute("value");
                    quantity = int.Parse(driver.FindElement(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[" + j + "]/td[3]/input")).GetAttribute("value"));
                    priceValue = decimal.Parse(priceValueWithDollar.Substring(1));
                    decimal calculatedSubtotal = priceValue * quantity;
                    if (!calculatedSubtotal.Equals(subTotal))
                    {
                        isEqual = false;
                        break;

                    }


                }
                if (isEqual)
                {
                    Console.WriteLine("SubTotal is displayed for the added item in cart");
                }
                else
                {
                    Console.WriteLine("SubTotal is not displayed for the added item in cart");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Subtotal is not displayed for the added items in cart", ex);
            }
        }

    }
}

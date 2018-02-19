using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;


namespace SeleniumParallelTest
{
    class QuotePage
    {
        protected IWebDriver driver;
        private By getlifequote = By.CssSelector("#getlifequote");
        private By getcarquote = By.CssSelector("#getcarquote");


        public QuotePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public QuotePage() { 
        
        }
        public LifeInsurancePage clickGetLifeQtute()
        {
            driver.FindElement(getlifequote).Click();
            wait(6,driver);
            return new LifeInsurancePage(driver);
        }

        public void clickGetCarQuote() {
            driver.FindElement(getcarquote).Click();
            Console.WriteLine("test!");
            wait(6,driver);
        }
        public void wait(int sec, IWebDriver driver)
        {
          
            //Explicit Waits
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));
            try
            {
                IWebElement element = wait.Until
                (ExpectedConditions.ElementToBeClickable
                (By.Id("someid")));
            }
            catch {
                
                return;
            } 
          
         
        }
    }
}

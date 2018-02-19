using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Configuration;
using OpenQA.Selenium.Support.UI;


namespace SeleniumParallelTest
{
    class LifeInsurancePage
    {
        protected IWebDriver driver;
        private By age = By.CssSelector("#age");
        private By email = By.CssSelector("#email");
        private By male = By.CssSelector("#male");
        private By female = By.CssSelector("#female");
        private By occupation = By.CssSelector("#occupation");
        private By State = By.CssSelector("#state");
        private By getQuote = By.CssSelector("#getquote");

        private By buyInsurance = By.CssSelector("#payment");

        private String Age = ConfigurationManager.AppSettings.Get("Age");
        private String Email = ConfigurationManager.AppSettings.Get("Email");
        private String gender = ConfigurationManager.AppSettings.Get("gender");
        private String Occu = ConfigurationManager.AppSettings.Get("occupation");
        private String state = ConfigurationManager.AppSettings.Get("State");

        QuotePage quotepage = new QuotePage();

        public LifeInsurancePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public LifeInsurancePage selectGender() {
            
            if (gender=="male")
            {
                driver.FindElement(male).Click();
                quotepage.wait(2,driver);
            }
            else {
                driver.FindElement(female).Click();
                quotepage.wait(2,driver);
              }
                    return this;
        }
        public LifeInsurancePage selectCategory() {

            var dropdown = new SelectElement(driver.FindElement(occupation));
            dropdown.SelectByText(Occu);
            quotepage.wait(2,driver);
            return this;
        }
        public LifeInsurancePage selectState() {
            var dropdown = new SelectElement(driver.FindElement(State));
            dropdown.SelectByText(state);
            quotepage.wait(2,driver);
            return this;
        }
        public LifeInsurancePage clickGetQuote() {

            driver.FindElement(getQuote).Click();
            quotepage.wait(3,driver);
            return this;
        }

        public InsurancePaymentPage clickBuyInsurance()
        {
            driver.FindElement(buyInsurance).Click();
            quotepage.wait(3,driver);
            return new InsurancePaymentPage(driver);
        }
        public  LifeInsurancePage enterAge() {
            driver.FindElement(age).SendKeys(Age);
            quotepage.wait(6,driver);
            return this;
        }
        public LifeInsurancePage enterEmail()
        {
            driver.FindElement(email).SendKeys(Email);
            quotepage.wait(6,driver);
            return this;
        }

        public bool verifyBuyInsurance()

        {
           
            if (!driver.FindElement(buyInsurance).Displayed)
            {
                return false;
            }
                return true;
                
        }
        public string isgetText() {
          
            string acutal_ = driver.FindElement(buyInsurance).Text;
            return acutal_;
        }
    }
}

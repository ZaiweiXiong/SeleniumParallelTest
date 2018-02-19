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
    class InsurancePaymentPage
    {
        protected IWebDriver driver;
        private By name = By.CssSelector("#cardholdername");
        private By emailUsrname = By.CssSelector("input[id='username'][class='form-control']");
        private By password = By.CssSelector("input[id='password'][class='form-control']");

       
        private By expirationMonth = By.CssSelector("#expiry-month");
        private By expirationYear = By.CssSelector("[name='expiry-year']");
        private By cardCVV = By.CssSelector("#cvv");
        private By payNowButton = By.CssSelector("#pay");
        private By CardName = By.CssSelector("#card-number");
        private By month = By.CssSelector("#expiry-month");
        private By year = By.CssSelector("[name='expiry-year']");
        private By cc = By.CssSelector("#cvv");
        private By paynow = By.CssSelector("#pay");

        private By PayMsg = By.CssSelector(".panel-title.text-center>i");

        
        private String Name = ConfigurationManager.AppSettings.Get("Name");
        private String Username = ConfigurationManager.AppSettings.Get("Username");
        private String Password = ConfigurationManager.AppSettings.Get("Password");
        private String CardNumber = ConfigurationManager.AppSettings.Get("CardNumber");
        private String Month = ConfigurationManager.AppSettings.Get("Month");
        private String Year = ConfigurationManager.AppSettings.Get("Years");
        private String CardCVV = ConfigurationManager.AppSettings.Get("Cardcvv");

        QuotePage quotepage = new QuotePage();

        public InsurancePaymentPage(IWebDriver driver)
        {
            this.driver = driver;


        }
        public InsurancePaymentPage entryName() {
            driver.FindElement(name).SendKeys(Name);
            quotepage.wait(3,driver);
            return this;
        }
        public InsurancePaymentPage entryEmail() {
            driver.FindElement(emailUsrname).SendKeys(Username);
            quotepage.wait(3,driver);
            return this;
        }
        public InsurancePaymentPage entryPassword() {
            driver.FindElement(password).SendKeys(Password);
            quotepage.wait(3,driver);
            return this;
        }
        public InsurancePaymentPage entryCardNumber() {
            driver.FindElement(CardName).SendKeys(CardNumber);
            quotepage.wait(3,driver);
            return this;
        }
        public InsurancePaymentPage selectExpirationDate() {
            var dropdown = new SelectElement(driver.FindElement(month));
            dropdown.SelectByText(Month);
            quotepage.wait(3,driver);
            dropdown = new SelectElement(driver.FindElement(year));
            dropdown.SelectByText(Year);
            quotepage.wait(3,driver);
            return this;
        }
        public InsurancePaymentPage enterCardcvv() {
            driver.FindElement(cc).SendKeys(CardCVV);
            quotepage.wait(3,driver);
            return this;
        }

        public InsurancePaymentPage clickPayNow() {
            driver.FindElement(paynow).Click();
            quotepage.wait(3,driver);
            return this;
        }

        public bool verifySuccessPayMessage()
        {
            return driver.FindElement(PayMsg).Text.Contains("Sucessful"); 
        }
    }
}

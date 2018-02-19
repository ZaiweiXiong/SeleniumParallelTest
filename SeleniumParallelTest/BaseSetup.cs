using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System.Configuration;


namespace SeleniumParallelTest
{
    [TestFixture]
    public class BaseSetup
    {

        protected  IWebDriver browser;
        private String URL = ConfigurationManager.AppSettings.Get("URL");

        public BaseSetup (){
          Console.WriteLine("BaseSetup");
        }

        public IWebDriver initBrowser() {

           
            return new InternetExplorerDriver();
        }

        [SetUp]
        public void StartBrowser(){
              
             browser =initBrowser() ;
             browser.Navigate().GoToUrl(URL);
        }

        [TearDown]
        public void closeBrowser(){

            browser.Manage().Cookies.DeleteAllCookies();
            browser.Close();
            browser.Quit();
        }
    }  
}

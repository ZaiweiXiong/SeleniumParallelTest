using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;

namespace SeleniumParallelTest
{

    [TestFixture]
    class TestFroms : BaseSetup
    {

        [Test]
        [Parallelizable]

          public void GetLifeQuote(){

          QuotePage quotepage = new QuotePage(browser);
          LifeInsurancePage lifeinsurancepage= quotepage.clickGetLifeQtute();
          lifeinsurancepage.enterAge().selectGender().selectCategory().
          selectState().enterEmail().clickGetQuote();
          Assert.AreEqual(lifeinsurancepage.isgetText(), "Buy Insurance");
          InsurancePaymentPage insurancePaymentPage= lifeinsurancepage.clickBuyInsurance();
          insurancePaymentPage.entryName().entryEmail().entryPassword().entryCardNumber()
          .selectExpirationDate().enterCardcvv().clickPayNow().verifySuccessPayMessage();
           
        }
    }

     
    [TestFixture]
   
    class TestChrome : BaseSetup
    {
        [Test]
        [Parallelizable]
        public void GetCarQuote(){
            QuotePage quotepage = new QuotePage(browser);
            quotepage.clickGetCarQuote();
          
         }
    }
}

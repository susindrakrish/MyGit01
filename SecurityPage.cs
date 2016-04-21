using System;
using OpenQA.Selenium;
using DomainUiLive.PageRepository.PageFactory.CMS;
using DomainUiLive.Tools.Helpers;
using NUnit.Framework;
using System.Threading;

namespace DomainUiLive.PageRepository.Pages.CMS
{
    class SecurityPage : SecurityPageFactory
    {
        private readonly CartPageFactory _cart;
        public SecurityPage(IWebDriver driver) : base(driver)
        {
            _cart = new CartPageFactory(driver);
        }
        public void PurchaseSSLCertificates(IWebDriver driver, String sectionUrl)
        {
            driver.Navigate().GoToUrl(sectionUrl);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            SslUI_CompareProdBtn.Click();
            SslUI_AddToCartBtn.Click();
            SslUI_ConfirmOrderBtn.Click();
            Thread.Sleep(6000);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            Assert.IsTrue(_cart.CartUI_OrderSummaryTxtBlk.Text.Contains(UiConstants.POSITIVE_SSL));

            /*  Checks for SANDBOX & LIVE Environments      
            Purchases and makes Payment if SandBox else navigates to Paypal and back  */
            CommonUtils.ExecEnvBasedPaymentFlow(driver, _cart);
        }

        public void PurchaseWhoIsGuard(IWebDriver driver, String sectionUrl, String domainname )
        {   
            driver.Navigate().GoToUrl(sectionUrl);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            WhoIsGuardUI_AddToCartBtn.Click();
            WhoIsGuardUI_PurchaseNewDomainBtn.Click(); 
            WhoIsGuardUI_DomainInputTxt.SendKeys(domainname);
            SecurityUI_AddNewDomainToCartBtn.Click();
            _cart.CartUI_ContinueBtn.Click();            
            _cart.CartUI_ConfirmOrderBtn.Click();
            Thread.Sleep(6000);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            CommonUtils.VerifyOrderSummary(_cart.OrderUI_OrderSummary.Text, domainname);

            /*  Checks for SANDBOX & LIVE Environments      
            Purchases and makes Payment if SandBox else navigates to Paypal and back  */
            CommonUtils.ExecEnvBasedPaymentFlow(driver, _cart);
        }
    }
}

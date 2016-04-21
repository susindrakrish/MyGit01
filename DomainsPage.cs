using System;
using System.Threading;
using OpenQA.Selenium;
using DomainUiLive.PageRepository.PageFactory.CMS;
using DomainUiLive.Tools.Helpers;
using NUnit.Framework;

namespace DomainUiLive.PageRepository.Pages.CMS 
{
    class DomainsPage : DomainsPageFactory 
    {
        private readonly CartPageFactory _cart;
        private readonly HostingPage _hostingPage;
        public DomainsPage(IWebDriver driver) : base(driver)
        {
            _cart = new CartPageFactory(driver);
            _hostingPage = new HostingPage(driver);
        } 
        public void RegisterDomain(IWebDriver driver, String sectionUrl, String domainname)
        {
            DomainRegistration(driver, sectionUrl, domainname);

            /*  Checks for SANDBOX & LIVE Environments      
            Purchases and makes Payment if SandBox else navigates to Paypal and back  */

            CommonUtils.ExecEnvBasedPaymentFlow(driver, _cart);
        }
        public void TransferDomain(IWebDriver driver, String sectionUrl, String domainname)
        {
            driver.Navigate().GoToUrl(sectionUrl);
            DomainTransferUI_InputTxt.SendKeys(domainname); 
            DomainRegisterUI_SearchBtn.Click();
            Thread.Sleep(8000);
            DomainTransferUI_AddtoCartBtn.Click();
            Thread.Sleep(8000);
            _cart.CartUI_ViewCartBtn.Click();            
            _cart.CartUI_ConfirmOrderBtn.Click();
            Thread.Sleep(8000);
            Assert.IsTrue(_cart.OrderUI_OrderReviewSectionTitle.Displayed);
            Thread.Sleep(8000);
            var orderSummary = _cart.OrderUI_OrderSummary.Text;
            Assert.IsTrue(orderSummary.Contains(domainname.ToLower())); 
            Assert.IsTrue(orderSummary.Contains(UiConstants.DOMAIN_TRANSFER));
            Thread.Sleep(8000);

            /*  Checks for SANDBOX & LIVE Environments 
            Purchases and makes Payment if SandBox else navigates to Paypal and back  */
            CommonUtils.ExecEnvBasedPaymentFlow(driver, _cart);
        }
        public void RegisterPersonalDomain(IWebDriver driver, String sectionUrl, String domainfirstname, String domainlastname)
        {
            driver.Navigate().GoToUrl(sectionUrl);
            PersonalDomainUI_FirstnameTxt.SendKeys(domainfirstname);
            PersonalDomainUI_LastnameTxt.SendKeys(domainlastname);
            PersonalDomainSearchBtn.Click();
            PersonalDomainUI_AddtoCartBtn.Click();

            /*  Checks for SANDBOX & LIVE Environments      
            Purchases and makes Payment if SandBox else navigates to Paypal and back  */
            if (!ConfigHelper.MainUrl.Contains(UiConstants.BRANCHES))
            {
                _cart.CartUI_ContinueBtn.Click();
                _cart.CartUI_ContinueBtn.Click();                
                _cart.CartUI_ConfirmOrderBtn.Click();
                Thread.Sleep(6000);
                Assert.IsTrue(_cart.OrderUI_OrderReviewSectionTitle.Displayed);
               CommonUtils.ExecEnvBasedPaymentFlow(driver, _cart);
            }
        }
        public void PurchaseFreeDNS(IWebDriver driver, String sectionUrl, String domainname)
        {
            driver.Navigate().GoToUrl(sectionUrl);
            FreeDnsUI_InputTxt.SendKeys(domainname);
            Thread.Sleep(8000);
            FreeDnsUI_GetDnsBtn.Click();
            Thread.Sleep(8000);
            FreeDnsUI_AddtoCartBtn.Click();
            Thread.Sleep(8000);
            _cart.CartUI_ContinueBtn.Click();
            Thread.Sleep(8000);
        }
        public void PurchaseDomainInThreePaymentMode(IWebDriver driver, String sectionUrl)
        {
            String[] paymentModes = new[] { "card", "paypal", "funds" };
            foreach (var paymentMode in paymentModes)
            {
                String domainname = DataHelper.GetRandomString(15) + UiConstants.TLD_BIKE;
                DomainRegistration(driver, sectionUrl, domainname);
                CommonUtils.ExecEnvBasedThreePaymentFlow(driver, _cart, paymentMode);
            }
        }

        public void DomainRegistration(IWebDriver driver, String sectionUrl, String domainname)
        {
            driver.Navigate().GoToUrl(sectionUrl);
            DomainRegisterUI_SearchTxt.SendKeys(domainname);
            DomainRegisterUI_SearchBtn.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(1.00));
            DomainRegisterUI_AddToCartBtn.Click();
            Thread.Sleep(8000);
            _cart.CartUI_ViewCartBtn.Click();
            Thread.Sleep(6000);
            _cart.CartUI_ConfirmOrderBtn.Click();
            Thread.Sleep(6000);
        }

        public void RegisterPremiumDomain(IWebDriver driver, String sectionUrl, String domainname)
        {
            driver.Navigate().GoToUrl(sectionUrl);
            DomainRegisterUI_SearchTxt.SendKeys(domainname);
            DomainRegisterUI_SearchBtn.Click();

            Thread.Sleep(25000);
            int count = driver.FindElements(By.XPath(UiConstants.PREMIUMDOMAINDIV)).Count;
            if (!count.Equals(0))
            {
                PremiumDomainUI_AddToCartBtn.Click();
                Thread.Sleep(10000);
                _cart.CartUI_ViewCartBtn.Click();
                Assert.IsTrue(PremiumDomainUI_PremiumTxt.Text.Contains("PREMIUM"));
                _cart.CartUI_ConfirmOrderBtn.Click();
            }
            else
            {
                throw new Exception("USER EXCEPTION : UNABLE TO FIND PREMIUM DOMAINS FOR : " + domainname);
            }

            CommonUtils.ExecEnvBasedPaymentFlow(driver, _cart);
        }

        public void RegisterPremiumDNS(IWebDriver driver, String sectionUrl, String domainname)
        {
            driver.Navigate().GoToUrl(UrlHelper.PageSecurityPremiumDNS);
            PremiumDnsUI_AddToCartBtn.Click();
            _hostingPage.HostingUI_PurchaseNewDomainBtn.Click();
            _hostingPage.HostingUI_DomainInputTxt.SendKeys(domainname);
            Thread.Sleep(5000);
            _hostingPage.HostingUI_AddNewDomainToCartBtn.Click();
            Thread.Sleep(2000);
            _cart.CartUI_ContinueBtn.Click();

            if (PremiumDnsUI_ToggleTxt.Text.Contains(UiConstants.ENABLE))
            {
                _hostingPage.SharedUI_ConfirmOrderBtn.Click();
            }
            else
            {
                throw new Exception("USER EXCEPTION : THIS IS NOT A PREMIUM DNS : " + domainname);
            }

            CommonUtils.ExecEnvBasedPaymentFlow(driver, _cart);
        }
    }
}
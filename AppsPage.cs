using System;
using OpenQA.Selenium;
using DomainUiLive.PageRepository.PageFactory.CMS;
using DomainUiLive.Tools.Helpers;
using NUnit.Framework;
using System.Threading;

namespace DomainUiLive.PageRepository.Pages.CMS
{
    class AppsPage : AppsPageFactory
    {
        private readonly CartPageFactory _cart;
        public AppsPage(IWebDriver driver) : base(driver)  
        {
            _cart = new CartPageFactory(driver); 
        }
        public void PurchaseAppsForWebsite(IWebDriver driver, String sectionUrl, String domainname)
        {   
            driver.Navigate().GoToUrl(sectionUrl);            
            AppsMrktPlaceUI_AddToCartBtn.Click();
            Thread.Sleep(6000);
            AppsMrktPlaceUI_PurchaseNewDomainBtn.Click();
            AppsMrktPlaceUI_DomainInputTxt.SendKeys(domainname);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            _cart.CartUI_AddNewDomainToCartBtn.Click();            
            _cart.CartUI_ContinueBtn.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            _cart.CartUI_ConfirmOrderBtn.Click();
            Thread.Sleep(6000);

            /*  Checks for SANDBOX & LIVE Environments      
            Purchases and makes Payment if SandBox else navigates to Paypal and back  */
            CommonUtils.ExecEnvBasedPaymentFlow(driver, _cart);
        } 
        public void PurchaseAppsForBrandIdentity(IWebDriver driver, String sectionUrl)
        {
            driver.Navigate().GoToUrl(sectionUrl);
            Thread.Sleep(4000);
            AppsMrktPlaceUI_BrandIdentityTab.Click();
            Thread.Sleep(4000);
            AppsMrktPlaceUI_UpliftSocialBtn.Click();
            AppsMrktPlaceUI_UpliftSocialAddToCartBtn.Click();
            AppsMrktPlaceUI_UpliftSocialConfirmOrderBtn.Click();
            Assert.IsTrue(_cart.OrderUI_OrderReviewSectionTitle.Text.Contains(UiConstants.ORDER_REVIEW));

            /*  Checks for SANDBOX & LIVE Environments      
            Purchases and makes Payment if SandBox else navigates to Paypal and back  */
            CommonUtils.ExecEnvBasedPaymentFlow(driver, _cart);
        }
        public void PurchaseAppsForToolsInvoiced(IWebDriver driver, String sectionUrl)
        {
            driver.Navigate().GoToUrl(sectionUrl);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(1.00));

            AppsMrktPlaceUI_ToolsTab.Click();
            Thread.Sleep(6000);
            AppsMrktPlaceUI_InvoicedLnk.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(1.00));
            AppsMrktPlaceUI_UpliftSocialAddToCartBtn.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(1.00));
            AppsMrktPlaceUI_UpliftSocialConfirmOrderBtn.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(1.00));
            Assert.IsTrue(_cart.OrderUI_OrderReviewSectionTitle.Text.Contains(UiConstants.ORDER_REVIEW));

            CommonUtils.ExecEnvBasedPaymentFlow(driver, _cart);
        }
        public void PurchaseAppsForNCDomains(IWebDriver driver, String sectionUrl)
        {
            driver.Navigate().GoToUrl(sectionUrl);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(1.00));
            AppsMrktPlaceUI_WeeblyBtn.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(1.00));
            AppsMrktPlaceUI_UpliftSocialAddToCartBtn.Click();
            Thread.Sleep(8000);
            AppsMrktPlaceUI_OwnDomainBtn.Click();
            int len;
            Int32.TryParse(
                ((IJavaScriptExecutor)driver).ExecuteScript(" return document.getElementsByClassName('result').length;")
                    .ToString(), out len);
            if (len > 0)
            {
                AppsMrktPlaceUI_SelectDomainLnk.Click();

                _cart.CartUI_ContinueBtn.Click();

                AppsMrktPlaceUI_UpliftSocialConfirmOrderBtn.Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(1.00));
                Assert.IsTrue(_cart.OrderUI_OrderReviewSectionTitle.Text.Contains(UiConstants.ORDER_REVIEW));

                CommonUtils.ExecEnvBasedPaymentFlow(driver, _cart);
            }
            else
            {
                Assert.Throws<Exception>(() => len = 0, "FAILURE DUE TO INSUFFICIENT DATA : No Domains are displayed to purchase an Apps.");
            }
        }
        public void AppsSubscription(IWebDriver driver, String sectionUrl)          //  Apps Subscriptions
        {
            driver.Navigate().GoToUrl(sectionUrl);
            Thread.Sleep(10000);

            if (AppsSubsUI_ContainerDiv.GetAttribute("class").Contains("subscription"))
            {
                Assert.IsTrue(AppsSubsUI_FilterDropDownBtn.Displayed);
                AppsSubsUI_FilterDropDownBtn.Click();
                AppsSubsUI_SortByDropDownAllBtn.Click();
                Assert.IsTrue(AppsSubsUI_SortByDropDownBtn.Displayed);
                AppsSubsUI_SortByDropDownBtn.Click();
                AppsSubsUI_SortByLatestDropDownBtn.Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                AppsSubsUI_SortByDropDownBtn.Click();
                AppsSubsUI_SortByOldestDropDownBtn.Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(40));
                Assert.IsTrue(AppsSubsUI_ViewStatementLnk.Displayed);
                Assert.IsTrue(AppsSubsUI_PaymentMethodLnk.Displayed);
                Assert.IsTrue(AppsSubsUI_ViewAppStoreLnk.Displayed);
                Assert.IsTrue(AppsSubsUI_WebsiteLnk.Displayed);
                Assert.IsTrue(AppsSubsUI_SupportLnk.Displayed);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            }
            if (AppsSubsUI_ContainerDiv.GetAttribute("class").Contains("center"))
            {
                Assert.Throws<Exception>(() => AppsSubsUI_ContainerDiv.GetAttribute("class").Contains("center"), "FAILURE DUE TO INSUFFICIENT DATA : No Apps are displayed in subscription page.");
            }
        }
    }
}
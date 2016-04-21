using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using DomainUiLive.PageRepository.PageFactory.CMS;
using DomainUiLive.Tools.Helpers;
using NUnit.Framework;
using System.Threading;

namespace DomainUiLive.PageRepository.Pages.CMS
{
    class HostingPage : HostingPageFactory   
    {
        private CartPageFactory _cart;
        public static String _orderNumber = String.Empty; 
        public HostingPage(IWebDriver driver) : base(driver)
        {
            _cart = new CartPageFactory(driver); 
        } 
        public void PurchaseSharedHosting(IWebDriver driver, String sectionUrl, String domainname, int flag)  
        {
            CartPageFactory _cart = new CartPageFactory(driver); 
            driver.Navigate().GoToUrl(sectionUrl);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            SharedUI_AddToCartBtn.Click();
            HostingUI_PurchaseNewDomainBtn.Click();            
            HostingUI_DomainInputTxt.SendKeys(domainname);
            HostingUI_AddNewDomainToCartBtn.Click();              
            _cart.CartUI_ContinueBtn.Click();  

            // Check Flag (1 = NewUser; 2 = Existing User)
            if (flag == 1)
                NewUserSharedUI_ConfirmOrderBtn.Click();
            else if (flag == 2)
                SharedUI_ConfirmOrderBtn.Click();

            if(ConfigHelper.MainUrl.Contains(UiConstants.SANDBOX))
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
                wait.Until(ExpectedConditions.TextToBePresentInElement(_cart.OrderUI_OrderReviewSectionTitle,
                    UiConstants.ORDER_REVIEW));
                var orderSummary = SharedUI_OrderSummaryTxt.Text;
                CommonUtils.VerifyOrderSummary(orderSummary, domainname);
            }
            else
            {
                if (flag == 2)
                {
                    var orderUrl = driver.Url;
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));                    
                    Assert.IsTrue(orderUrl.Contains(UrlHelper.CartCheckout));
                }
            }
            Thread.Sleep(6000);
            CommonUtils.ExecEnvBasedPaymentFlow(driver, _cart);
        }
        public void PurchaseReSellerHosting(IWebDriver driver, String sectionUrl, String domainname)
        {  
            driver.Navigate().GoToUrl(sectionUrl);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            ResellerUI_AddtoCartBtn.Click();
            HostingUI_PurchaseNewDomainBtn.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            ResellerUI_DomainInputTxt.SendKeys(domainname);
            HostingUI_AddNewDomainToCartBtn.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            _cart.CartUI_ContinueBtn.Click();
            _cart.CartUI_ContinueBtn.Click();            
            ResellerUI_ConfirmOrderBtn.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            CommonUtils.VerifyOrderSummary(_cart.CartUI_OrderSummaryTxtBlk.Text, domainname);
            Thread.Sleep(6000);

            /*  Checks for SANDBOX & LIVE Environments      
            Purchases and makes Payment if SandBox else navigates to Paypal and back  */
            CommonUtils.ExecEnvBasedPaymentFlow(driver, _cart);
        }
        public void PurchaseVPSHosting(IWebDriver driver, String sectionUrl, String domainname)
        {
            driver.Navigate().GoToUrl(sectionUrl);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            VpsUI_LiteAddtoCartBtn.Click();
            HostingUI_PurchaseNewDomainBtn.Click();            
            VpsUI_DomainInputTxt.SendKeys(domainname);
            HostingUI_AddNewDomainToCartBtn.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            _cart.CartUI_ContinueBtn.Click();
            _cart.CartUI_ContinueBtn.Click(); 

            _cart.CartUI_ConfirmOrderBtn.Click();
            
            CommonUtils.VerifyOrderSummary(_cart.CartUI_OrderSummaryTxtBlk.Text, domainname);
            var orderSummary = _cart.OrderUI_OrderSummary.Text;
            Assert.IsTrue(orderSummary.Contains(UiConstants.VPS_XEN_LITE));
            Thread.Sleep(6000);

            /*  Checks for SANDBOX & LIVE Environments      
            Purchases and makes Payment if SandBox else navigates to Paypal and back  */
            CommonUtils.ExecEnvBasedPaymentFlow(driver, _cart);
        } 
        public void PurchaseDedicatedServers(IWebDriver driver, String sectionUrl, String domainname)
        {
            driver.Navigate().GoToUrl(sectionUrl);
            Thread.Sleep(6000);
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            DedicatedUI_CpuOrderBtn.Click();
            HostingUI_PurchaseNewDomainBtn.Click();            
            DedicatedUI_DomainInputTxt.SendKeys(domainname);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            HostingUI_AddNewDomainToCartBtn.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            DedicatedUI_FreeWebsiteContinueBtn.Click();
            _cart.CartUI_ContinueBtn.Click();
            DedicatedUI_FreeWebsiteConfirmOrderBtn.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Thread.Sleep(6000);

            /*  Checks for SANDBOX & LIVE Environments      
            Purchases and makes Payment if SandBox else navigates to Paypal and back  */
            CommonUtils.ExecEnvBasedPaymentFlow(driver, _cart);
        }        
        public void PurchasePrivateEmailHosting(IWebDriver driver, String sectionUrl, String domainname)
        {
            driver.Navigate().GoToUrl(sectionUrl);
            _cart = new CartPageFactory(driver);
            Random _random = new Random(DateTime.Now.Millisecond);
            int PE_TYPE = _random.Next(1, 3);

            switch (PE_TYPE)
            {
                case 1:
                    PEmailUI_PrivateAddtoCartBtn.Click();
                    break;
                case 2:
                    PEmailUI_BusinessAddtoCartBtn.Click();
                    break;
                case 3:
                    PEmailUI_BusinessOfficeAddtoCartBtn.Click();
                    break;
            }

            ////Randomize from 3 scenarios
            int PE_TYPE_DOMAIN = domainname.Equals(string.Empty)? _random.Next(1, 3): 3;
            
            switch (PE_TYPE_DOMAIN)
            {
                case 1:
                    throw new Exception("FAILURE DUE TO ENVIRONMENT : Domain Does Not Exist In Cart");
                case 2:
                    HostingUI_PurchaseNewDomainBtn.Click();
                    HostingUI_DomainFromAnotherRegistrarTxt.SendKeys(DataHelper.GetRandomAlphabets(8) + UiConstants.TLD_BIKE);
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                    HostingUI_AddNewDomainToCartBtn.Click();
                    break;
                case 3:
                    HostingUI_DomainInNamecheapBtn.Click();
                    Thread.Sleep(8000);
                    if (!domainname.Equals(string.Empty))
                        HostingUI_PE_ExistingDomainNameTxt.SendKeys(domainname);
                    Thread.Sleep(8000);
                    HostingUI_PE_ExistingDomainSelect.Click();
                    break;
               /* case 4:
                    HostingUI_DomainFromAnotherRegistrarBtn.Click();
                    HostingUI_DomainFromAnotherRegistrarTxt.SendKeys("flipkart.com");
                    System.Threading.Thread.Sleep(8000);
                    HostingUI_UseThisDomainBtn.Click();
                    break;
                case 5:
                    HostingUI_TransferDomainToNamecheapBtn.Click();
                    HostingUI_DomainFromAnotherRegistrarTxt.SendKeys("flipkart.com");
                    System.Threading.Thread.Sleep(8000);
                    HostingUI_UseThisDomainBtn.Click();
                    break; */
            }

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            _cart.CartUI_ContinueBtn.Click();
            _cart.CartUI_ContinueBtn.Click();

            _cart.CartUI_ConfirmOrderBtn.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            Thread.Sleep(6000);

            /*  Checks for SANDBOX & LIVE Environments      
            Purchases and makes Payment if SandBox else navigates to Paypal and back  */
            CommonUtils.ExecEnvBasedPaymentFlow(driver, _cart, "");
        }
    }
}

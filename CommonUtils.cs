using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing.Imaging;
using System.Threading;
using DomainUiLive.PageRepository.PageFactory.CMS;

namespace DomainUiLive.Tools.Helpers
{
    class CommonUtils 
    {
        public static By H3 = By.XPath(".//*[@class='cart']/header/h3");
        public static By PaypalNcLogo = By.XPath(".//img[@class='ng-scope']");
        static IWait<IWebDriver> _wait; 
        private static string _orderNumber;

        // **** Drives the flow of payment from cart based on environment ****
        public static void ExecEnvBasedPaymentFlow(IWebDriver driver, CartPageFactory cart,  [System.Runtime.CompilerServices.CallerMemberName] string callingmethod = "")
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

            //String paymentMethod = cart.CartUI_PaymentMethod.Text;
            String paymentMethod = cart.CartUI_PaymentMethod.Text.ToLower().Trim(); //PaymentMethod from Payment Details in Cart
            String paymentMode = ConfigHelper.PaymentMethod.ToLower();

            /*  Checks for SANDBOX & LIVE Environments   
            Purchases and makes Payment if SandBox else navigates to Paypal and back  */
            if (driver.Url.Contains(UiConstants.SANDBOX) || driver.Url.Contains(UiConstants.BRANCHES))
            {
                /*String paymentMethod = cart.CartUI_PaymentMethod.Text;*/ //PaymentMethod from Payment Details in Cart
                if (!paymentMethod.Equals(paymentMode, StringComparison.CurrentCultureIgnoreCase))
                {
                    cart.CartUI_ChangePaymentDetails.Click(); //CHANGE link to change Payment Method
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                    if (paymentMode.Equals("card", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cart.CartUI_RdoPaymentCard.Click();
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                        // New Card in Existing Account / New Account //Configuring New Card Details
                        if (cart.CartUI_CardDetailsDropdownTxt.Text.Equals("Add new card", StringComparison.CurrentCultureIgnoreCase))
                        {
                            //Adding New Card Details to Payment
                            AddNewCardToPayment(driver, cart);
                        }
                        // else payment continue with existing card
                        cart.CartUI_PaymentContinueBtn.Click();
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                    }
                    else if (paymentMode.Equals("paypal", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cart.CartUI_RdoPaymentPaypal.Click();
                        cart.CartUI_PaymentContinueBtn.Click();
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                    }
                    else
                    {
                        cart.CartUI_RdoPaymentFunds.Click();
                        cart.CartUI_PaymentContinueBtn.Click();
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                    }
                }
                ClickTermsAndConditions(driver, cart, callingmethod);
                DoPaymentAndVerifyOrder(driver, cart);
            }
            else
            {
                // For Production
                if (cart.CartUI_CartAmountValue.Text.Contains("$0.00"))
                {
                    ClickTermsAndConditions(driver, cart, callingmethod);
                    cart.CartUI_PayNowBtn.Click();
                }
                else
                {
                    if (!paymentMethod.Equals("paypal", StringComparison.CurrentCultureIgnoreCase))//((paymentMode.ToLower().Equals("funds")) || (paymentMode.ToLower().Equals("card")))
                    {
                        cart.CartUI_ChangePaymentDetails.Click();
                        cart.CartUI_RdoPaymentPaypal.Click();
                        cart.CartUI_ContinueBtn.Click();
                    }
                    ClickTermsAndConditions(driver, cart, callingmethod);
                    ClickPayPalAndBack(driver, cart);
                }
            }
        }
        public static void AddNewCardToPayment(IWebDriver driver, CartPageFactory cart)
        {
            //Adding New Card Details to Payment 
            cart.CartUI_NameOnCard.SendKeys(ConfigHelper.NameOnCard);
            cart.CartUI_CardNumber.SendKeys(ConfigHelper.CardNumber);
            cart.CartUI_CardCVV2.SendKeys(ConfigHelper.CardCVV2);
            cart.CartUI_CardExpiryMonth.SendKeys(ConfigHelper.CardExpiryMonth);
            cart.CartUI_CardExpiryYear.SendKeys(ConfigHelper.CardExpiryYear);
        }
        public static void ClickTermsAndConditions(IWebDriver driver, CartPageFactory cart, String callingmethod)
        {   
            String TermsDivXPath = ".//*[@id='aspnetForm']/div[contains(@class,'xxl-row-offset-one-twelfth')]/div[1]/div";
            int TermsDivCount = driver.FindElements(By.XPath(TermsDivXPath)).Count;

            for (int i = 1; i <= TermsDivCount; i++)
            {
                if (
                    driver.FindElement(By.XPath(TermsDivXPath + "[" + i + "]")).GetAttribute("class").Contains("your-cart-terms"))
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));

                    if (callingmethod.Contains(UiConstants.DEDICATED_SERVERS))
                        cart.CartUI_AltTermsAgreementsChk.Click();
                    else
                        cart.CartUI_TermsAgreementsChk.Click();

                    if (cart.CartUI_TermsDiv.GetAttribute("id").Contains("raaPanel"))
                        cart.CartUI_ConfirmContactChk.Click();
                }
            }
        }
        public static void DoPaymentAndVerifyOrder(IWebDriver driver, CartPageFactory cart)
        {
            DoPayment(driver, cart);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(1.00));
            VerifyPurchaseSummary(cart, driver);
            _orderNumber = GetOrderNumberForPurchase(cart);
        }
        // **** Verifies the Order Summary before payment ****
        public static void VerifyOrderSummary(string ordersummary, string domainname)
        {
            Assert.IsTrue(ordersummary.Contains(domainname.ToLower())); 
            Assert.IsTrue(ordersummary.Contains(UiConstants.DOMAIN_REGISTRATION));
        }
        // **** Makes the Payment using Account Funds in SandBox ****
        public static void DoPayment(IWebDriver driver, CartPageFactory cart )
        {
            if (cart.CartUI_PaymentMethod.Text.ToLower().Contains("paypal"))
                ClickPayPalAndDoPayment(driver, cart);
            else
                cart.CartUI_PayNowBtn.Click();
        }

     /* public static void ClickPayPalAndDoPayment(IWebDriver driver, CartPageFactory cart)
        {
            cart.CartUI_PayPalBtn.Click();
            string pgTitle = driver.Title;
            Assert.IsTrue(pgTitle.Contains(UiConstants.PAYPAL));
            cart.CartUI_PaypalEmailInput.SendKeys(ConfigHelper.PayPalEmail);
            cart.CartUI_PaypalPasswordInput.SendKeys(ConfigHelper.PayPalPassword);
            cart.CartUI_PaypalSubmitBtn.Click();
            Thread.Sleep(10000);
            cart.CartUI_PaypalContinueBtn.Click();
        } */ 

        // **** Verifies the Purchase Summary after payment ****
        public static void VerifyPurchaseSummary(CartPageFactory cart, IWebDriver driver) 
        {   
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            webDriverWait.Until(d => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));            
            Assert.IsTrue(cart.CartUI_PurchaseSummaryHeader.Text.Contains(UiConstants.PURCHASE_SUMMARY));            
        }
        public static string GetOrderNumberForPurchase(CartPageFactory cart)
        {   
            string orderNumber = cart.CartUI_OrderNumber.Text.Trim();
            return orderNumber;
        }
        // **** Navigates to Paypal page and validates the landing page in Zones and Production ****
        public static void ClickPayPalAndBack(IWebDriver driver, CartPageFactory cart)
        {   
            cart.CartUI_PayPalBtn.Click();
            string pgTitle = driver.Title;
            Assert.IsTrue(pgTitle.Contains(UiConstants.PAYPAL)); 
            driver.Navigate().Back(); 
        }
        public static void CheckAccountFundsAsPayment(IWebDriver driver, CartPageFactory cart)
        {
            driver.Navigate().GoToUrl(UrlHelper.PageProfileBilling);

            String selectedPayment = cart.CartUI_SelectedPayment.Text;

            if (selectedPayment.Equals(UiConstants.ACCOUNTFUNDS) == false)
            {
                cart.CartUI_EditBtn.Click();
                cart.CartUI_ChkOutFundsRdo.Click();
                cart.CartUI_SaveChangesBtn.Click(); 

            }
        }
        public static void ExecEnvBasedThreePaymentFlow(IWebDriver driver, CartPageFactory cart, String ModeOfPayment, [System.Runtime.CompilerServices.CallerMemberName] string callingmethod = "")
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            /*  Checks for SANDBOX & LIVE Environments   
            Purchases and makes Payment if SandBox else navigates to Paypal and back  */
            if (ConfigHelper.MainUrl.Contains(UiConstants.SANDBOX) || ConfigHelper.MainUrl.Contains(UiConstants.BRANCHES))
            {
                //Added by Sriram - Start
                String paymentMethod = cart.CartUI_PaymentMethod.Text; //PaymentMethod from Payment Details in Cart
                String paymentMode = (ModeOfPayment != string.Empty)
                    ? ModeOfPayment
                    : ConfigHelper.PaymentMethod.ToLower();
                if (!paymentMethod.Equals(paymentMode, StringComparison.CurrentCultureIgnoreCase))
                {
                    cart.CartUI_ChangePaymentDetails.Click(); //click CHANGE link to change Payment Method
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                    if (paymentMode.Equals("card", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cart.CartUI_RdoPaymentCard.Click();
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
                        //Existing Card or New Card
                        if (cart.CartUI_CardDetailsDropdownTxt.Text.Contains("Add new card"))
                        {
                            //Adding New Card Details to Payment
                            AddNewCardToPayment(driver, cart);
                        }
                        else //Existing Card
                        {
                            // Add New Card
                            if (ConfigHelper.AddNewCard.ToLower().Equals("AddNewCard")) //\\ConfigHelper.AddNewCard.ToLower().Equals(("AddNewCard").ToLower())
                            {
                                //cart.CartUI_AccountFundsRdo.Click();
                                cart.CartUI_CardDetailsDropdownTxt.Click();
                                cart.CartUI_DropdownAddNewCard.Click();

                                AddNewCardToPayment(driver, cart);
                                if (cart.CartUI_CardBillingAddressDropDownTxt.Text.Contains("Add new contact"))
                                {
                                    cart.CartUI_CardBillingAddressDropDownTxt.Click();
                                    cart.CartUI_CardBillingDefaultAddress.Click();  // Default Account Contact
                                }
                                else if (cart.CartUI_CardBillingAddressDropDownTxt.Text.Contains("Use previously saved contact"))
                                {
                                    cart.CartUI_CardBillingAddressDropDownTxt.Click();
                                    cart.CartUI_CardBillingDefaultAddress.Click();
                                }
                                else
                                {
                                    if (cart.CartUI_CardAddressTopDiv.Displayed)
                                    {
                                        cart.CartUI_CardBillingAddressDropDownTxt.Click();
                                        cart.CartUI_CardBillingAddNewAddress.Click();
                                        cart.CartUI_CardBillingAddressDropDownTxt.Click();
                                        cart.CartUI_CardBillingDefaultAddress.Click();
                                    }
                                }
                            }
                            //else continue with existing card
                        }
                        cart.CartUI_PaymentContinueBtn.Click();
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                        ClickTermsAndConditions(driver, cart, callingmethod);
                        DoPaymentAndVerifyOrder(driver, cart);
                    }
                    else if (paymentMode.Equals("paypal", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cart.CartUI_RdoPaymentPaypal.Click();
                        cart.CartUI_PaymentContinueBtn.Click();
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                        ClickTermsAndConditions(driver, cart, callingmethod);
                        //ClickPayPalAndBack(driver, cart);
                        ClickPayPalAndDoPayment(driver, cart);
                        //DoPaymentAndVerifyOrder(driver, cart);
                    }
                    else
                    {
                        cart.CartUI_RdoPaymentFunds.Click();
                        cart.CartUI_PaymentContinueBtn.Click();
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                        ClickTermsAndConditions(driver, cart, callingmethod);
                        DoPaymentAndVerifyOrder(driver, cart);
                    }
                }
                else
                {
                    ClickTermsAndConditions(driver, cart, callingmethod);
                    DoPaymentAndVerifyOrder(driver, cart);
                }
            }
            else
            {
                String paymentMethod = cart.CartUI_PaymentMethod.Text; //PaymentMethod from Payment Details in Cart
                //setting PayPal as default Payment Setting for the User
                if (!paymentMethod.Equals(UiConstants.PAYPAL,StringComparison.CurrentCultureIgnoreCase))
                {
                    string currentUrl = driver.Url;
                    CheckPaypalAsPayment(driver, cart);
                    driver.Navigate().GoToUrl(currentUrl);
                }
                ClickTermsAndConditions(driver, cart, callingmethod);
                ClickPayPalAndBack(driver, cart);
            }
        }


        public static void ClickPayPalAndDoPayment(IWebDriver driver, CartPageFactory cart)
        {   
            cart.CartUI_PayPalBtn.Click();
            string pgTitle = driver.Title;
            Assert.IsTrue(pgTitle.Contains(UiConstants.PAYPAL));

            cart.CartUI_PaypalEmailInput.SendKeys(ConfigHelper.PayPalEmail);
            cart.CartUI_PaypalPasswordInput.SendKeys(ConfigHelper.PayPalPassword);
            cart.CartUI_PaypalSubmitBtn.Click();
            Thread.Sleep(10000);

            //Verifying the "Your order summary"
            cart.CartUI_PaypalContinueBtn.Click();
            //driver.Navigate().Back();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(1.00));
            VerifyPurchaseSummary(cart, driver);
            _orderNumber = GetOrderNumberForPurchase(cart);
        }
        
        public static void CheckPaypalAsPayment(IWebDriver driver, CartPageFactory cart)
        {
            driver.Navigate().GoToUrl(UrlHelper.PageProfileBilling);

            String selectedPayment = cart.CartUI_SelectedPayment.Text;
            if (selectedPayment.Equals(UiConstants.PAYPAL) == false)
            {
                cart.CartUI_EditBtn.Click();
                cart.CartUI_PaypalRdo.Click();
                cart.CartUI_SaveChangesBtn.Click();
            }
        }
        public static void TakeScreenshot(IWebDriver driver, string saveLocation)  
        {    
           var screenshotDriver = driver as ITakesScreenshot;
            if (screenshotDriver == null)
                return;
            var screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(saveLocation, ImageFormat.Png);            
        }
        public static void ClickWhenReady(IWebDriver driver, IWebElement webelement, int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(webelement));
            element.Click();
        }
        public static Boolean IsElementPresent(IWebDriver driver, string xpath) 
        {
            try
            {
                driver.FindElement(By.XPath(xpath));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
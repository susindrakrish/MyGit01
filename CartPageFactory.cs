using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects; 
using SeleniumSupport = OpenQA.Selenium.Support.PageObjects;

namespace DomainUiLive.PageRepository.PageFactory.CMS
{ 
    class CartPageFactory 
    {
        public CartPageFactory(IWebDriver driver)
        {
            SeleniumSupport.PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='popular-tab']/div/ul[1]/li[1]/a[2]")]
        public IWebElement CartUI_AddToCartBtn { get; set; }

        //[FindsBy(How = How.XPath, Using = "//a[@href='/cart/cart.aspx']")] 
        [FindsBy(How = How.XPath, Using = ".//*[contains(@class,'bottom side-cart')]/p[1]/a")]
        public IWebElement CartUI_ViewCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[contains(@class,'your-cart')]/div[2]/div[1]/div")]
        public IWebElement CartUI_OrderSummaryTxtBlk { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[3]/div[1]/div[3]/ul/li/div/label[3]/input")]
        public IWebElement CartUI_AccountFundsRdo { get; set; }
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='buynow']/div/div[2]/div/div[1]/p[1]/a")]
        public IWebElement CartUI_ConfirmOrderBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[3]/div[1]/div[4]/div[2]/div[1]/div")]
        public IWebElement CartUI_OrderSummaryBlk1 { get; set; }

        [FindsBy(How = How.XPath, Using = " .//*[@class='grid-col one-quarter']/div/div/p[1]/input")]
        //[FindsBy(How = How.XPath, Using = ".//*[@class='btn btn-block']")] 
        public IWebElement CartUI_PayNowBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='group checkout-terms']/label/span/input")]
        public IWebElement CartUI_TermsAgreementsChk { get; set; }  

        [FindsBy(How = How.XPath, Using = ".//*[contains(@id,'hostingPanel')]/label/span/input")] 
        public IWebElement CartUI_AltTermsAgreementsChk { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[contains(@id,'raaPanel')]/label/*[@class='termsandconditioncheckbox']/input")]
        public IWebElement CartUI_ConfirmContactChk { get; set; } 

        [FindsBy(How = How.XPath, Using = ".//*[@class='cart']/p[1]/input[@class='paypalcheckout']")]   
        public IWebElement CartUI_PayPalBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='your-cart summary group']/div[2]/h3")]  
        //[FindsBy(How = How.XPath, Using = ".//*[@class='your-cart summary group']/*[@class='page-title']/h3")]
        public IWebElement CartUI_PurchaseSummaryHeader { get; set; } 

        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_ConfirmationControl_orderSummaryPanel']/div[1]/div[1]/div[2]/div[1]/div[1]/h3")]
        public IWebElement OrderConfirmationPageTitle { get; set; } 

        [FindsBy(How = How.XPath, Using = "//h3[contains(.,'Order Review')]")] 
        public IWebElement OrderUI_OrderReviewSectionTitle { get; set; } 

        [FindsBy(How = How.XPath, Using = ".//*[@class='your-cart summary group']")] 
        public IWebElement OrderUI_OrderSummary { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[contains(@class,'valid availability')]")]
        public IWebElement CartUI_ValidAvailableTxtBlk { get; set; }
                
        //[FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[6]/div[1]/div[2]/ul/li/div/div[3]/a")]
        [FindsBy(How = How.XPath, Using = ".//a[@class='btn domain-select-new-btn']")]
        public IWebElement CartUI_AddNewDomainToCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='btn btn-block']")]
        public IWebElement Cart_ConfirmOrderBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnViewCart")]
        public IWebElement CartUI_ContinueBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='maincontent']/div[5]/div[2]/a")]
        public IWebElement CartUI_EditBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='maincontent']/form/div/div/div[1]/div[2]/div[3]/label")]
        public IWebElement CartUI_ChkOutFundsRdo { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='maincontent']/form/div/div/div[1]/div[2]/div[2]/label")]
        public IWebElement CartUI_PaypalRdo { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='maincontent']/form/div/div/div[2]/div/input")]
        public IWebElement CartUI_SaveChangesBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='maincontent']/form/div/div/div[2]/div/a")]
        public IWebElement CartUI_CancelBtn { get; set; } 

        [FindsBy(How = How.XPath, Using = ".//*[@id='maincontent']/div[5]/div[2]/div[2]/p[1]")]
        public IWebElement CartUI_SelectedPayment { get; set; }

        [FindsBy(How = How.XPath, Using  = ".//*[@class='your-cart-terms']/div[2]")]
        public IWebElement CartUI_ContactsDiv { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[contains(@class,'your-cart summary')]/div[contains(@class,'thank-you')]/p/strong")]
        public IWebElement CartUI_OrderNumber { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='product-group']/div/div/div[1]/span[1]")]
        public IWebElement CartUI_PEAddYearsDafaultText { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='grid-col three-quarters']/div[@class='your-cart-terms']")]
        public IWebElement CartUI_TermsDiv { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='product-group']//*[text()='Payment Method']/following::div[1]")]
        public IWebElement CartUI_PaymentMethod { get; set; }

        [FindsBy(How = How.LinkText, Using = "CHANGE")]
        public IWebElement CartUI_ChangePaymentDetails { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='po-r-1']")]
        public IWebElement CartUI_RdoPaymentCard { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='po-r-2']")]
        public IWebElement CartUI_RdoPaymentPaypal { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='po-r-3']")]
        public IWebElement CartUI_RdoPaymentFunds { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[contains(@class,'cart spacer-bottom side-cart')]/p/a")]
        public IWebElement CartUI_PaymentContinueBtn { get; set; }

        //Card
        [FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[3]/div[1]/div[2]/ul/li/div/div[1]/div[1]/div[1]/span[1]")]
        public IWebElement CartUI_CardDetailsDropdownTxt { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[3]/div[1]/div[2]/ul/li/div/div[1]/div[1]/div[2]/div/ul/li[1]")]
        public IWebElement CartUI_DropdownDefaultAccountCard { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[3]/div[1]/div[2]/ul/li/div/div[1]/div[1]/div[2]/div/ul/li[2]")]
        public IWebElement CartUI_DropdownAddNewCard { get; set; }

        //Add New Card
        [FindsBy(How = How.XPath, Using = ".//*[@id='Billing_name']")]
        public IWebElement CartUI_NameOnCard { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='ccc_number']")]
        public IWebElement CartUI_CardNumber { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='cc_cvc']")]
        public IWebElement CartUI_CardCVV2 { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='ccexp_month']")]
        public IWebElement CartUI_CardExpiryMonth { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='ccexp_year']")]
        public IWebElement CartUI_CardExpiryYear { get; set; }

        //Card Billing Address
        [FindsBy(How = How.XPath, Using = ".//*[@id='CardBillingAddressWithLabel']/div[1]/span[1]")]
        public IWebElement CartUI_CardBillingAddressDropDownTxt { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='CardBillingAddressWithLabel']/div[2]/div/ul/li[1]")]
        public IWebElement CartUI_CardBillingDefaultAddress { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='CardBillingAddressWithLabel']/div[2]/div/ul/li[2]")]
        public IWebElement CartUI_CardBillingAddNewAddress { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='CardAddressTopDiv']")]
        public IWebElement CartUI_CardAddressTopDiv { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[3]/div[2]/div/div/ul/li")]
        public IWebElement CartUI_CartAmountValue { get; set; }

        //Paypal Payment
        [FindsBy(How = How.Id, Using = "login_email")]
        public IWebElement CartUI_PaypalEmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "login_password")]
        public IWebElement CartUI_PaypalPasswordInput { get; set; }

        [FindsBy(How = How.Id, Using = "submitLogin")]
        public IWebElement CartUI_PaypalSubmitBtn { get; set; }

        [FindsBy(How = How.Id, Using = "continue")]
        public IWebElement CartUI_PaypalContinueBtn { get; set; }

    }
}

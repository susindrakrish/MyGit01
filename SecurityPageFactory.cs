using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumSupport = OpenQA.Selenium.Support.PageObjects;

namespace DomainUiLive.PageRepository.PageFactory.CMS
{
    class SecurityPageFactory
    {
        public SecurityPageFactory(IWebDriver driver)
        {
            SeleniumSupport.PageFactory.InitElements(driver, this);
        }

        // SSL Certificates
        [FindsBy(How = How.XPath, Using = "//a[@class='btn btn-block'][@href='/security/ssl-certificates/domain-validation.aspx']")]
        public IWebElement SslUI_CompareProdBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_productitem2_fieldsetLocationForProductList']/button")]
        public IWebElement SslUI_AddToCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/cart/checkout/default.aspx']")]
        public IWebElement SslUI_ConfirmOrderBtn { get; set; } 

        // WhoIsGuard
        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_ctl05_productAddToCartFieldset']/a")]
        public IWebElement WhoIsGuardUI_AddToCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='domain-select-options']//a[contains(text(),'Purchase a new domain')]")]
        public IWebElement WhoIsGuardUI_PurchaseNewDomainBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "  .//*[@class='domain-new-search']//input[contains(@placeholder,'desired domain name')]")]
        public IWebElement WhoIsGuardUI_DomainInputTxt { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='grid-col one-quarter']/div/div/p[1]/a")]
        public IWebElement WhoIsGuardUI_ConfirmOrderBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='po-r-2']")]
        public IWebElement WhoIsGuardUI_PaymentPaypalBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btn_Submit")]
        public IWebElement WhoIsGuardUI_PaymentContinueBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='btn domain-select-new-btn']")]
        public IWebElement SecurityUI_AddNewDomainToCartBtn { get; set; }     

    }
}

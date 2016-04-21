using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumSupport = OpenQA.Selenium.Support.PageObjects;

namespace DomainUiLive.PageRepository.PageFactory.CMS 
{
    class DomainsPageFactory
    {
        // Constructor that initialises the UI Elements of this class using the InitElements API of PageFactory
        public DomainsPageFactory(IWebDriver driver)
        {
            SeleniumSupport.PageFactory.InitElements(driver, this);
        }

        // Domain Registration

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_ctl00_inputSingleDomain")]
        public IWebElement DomainRegisterUI_SearchTxt { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_ctl00_heroContainer']/div[2]/fieldset/button")]
        public IWebElement DomainRegisterUI_SearchBtn_01 { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_ctl00_inputSingleDomain")]
        public IWebElement DomainRegisterUI_Input { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='ncRedirectButton  ga-event']")]
        public IWebElement DomainRegisterUI_SearchBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='#close']")]
        public IWebElement DomainRegisterUI_PopClose { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='embedDomainSearchResults']/div[2]/div[1]/a")]
        public IWebElement DomainRegisterUI_AddToCartBtn { get; set; }

        // Domain Transfer

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_ctl00_inputTransferDomain")]
        public IWebElement DomainTransferUI_InputTxt { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[@class='btn cart-add transfer']")]
        public IWebElement DomainTransferUI_AddtoCartBtn { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_ctl06_cartdetails")]
        public IWebElement DomainTransferUI_CartContentBtn { get; set; }

        // Free DNS

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_ctl00_inputFreeDNSDomain")]
        public IWebElement FreeDnsUI_InputTxt { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_ctl00_heroContainer']/div[2]/fieldset/button")]
        public IWebElement FreeDnsUI_GetDnsBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@id='addToPreCart']/a")]
        public IWebElement FreeDnsUI_AddtoCartBtn { get; set; }

        // Personal Domain

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_ctl00_inputFirstNameWithToggle")]
        public IWebElement PersonalDomainUI_FirstnameTxt { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_ctl00_inputLastNameWithToggle")]
        public IWebElement PersonalDomainUI_LastnameTxt { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='ncRedirectButton  ga-event']")]
        public IWebElement PersonalDomainSearchBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[contains(@class,'search-results')]/ul/li[3]/*[contains(@class,'btn cart-add')]")]
        public IWebElement PersonalDomainUI_AddtoCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[contains(@class,'register-premium-domain')][1]/a")]
        public IWebElement PremiumDomainUI_AddToCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='cart-item domain-name']/div//div[@class='price']//span[2]")]
        public IWebElement PremiumDomainUI_PremiumTxt { get; set; }


        //PremiumDNS

        // [FindsBy(How = How.XPath, Using = "//div[@class='grid-row group right-product-grid']//a[@class='ncRedirectButton btn']")]
        [FindsBy(How = How.XPath, Using = "//a[@class='ncRedirectButton btn']")]
        public IWebElement PremiumDnsUI_AddToCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='toggles']//div[@class='toggle-btn small premiumdns']//label")]
        public IWebElement PremiumDnsUI_ToggleTxt { get; set; }
        
    }
}

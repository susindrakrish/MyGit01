using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumSupport = OpenQA.Selenium.Support.PageObjects;

namespace DomainUiLive.PageRepository.PageFactory.CMS
{
    class HostingPageFactory
    {
        public HostingPageFactory(IWebDriver driver)
        {
            SeleniumSupport.PageFactory.InitElements(driver, this);
        }

        // Common UI Elements for Hosting

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Enter your desired domain name']")]
        public IWebElement HostingUI_DomainInputTxt { get; set; } 

        //[FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[6]/div[1]/div[2]/ul/li/div/div[3]/a")]
        [FindsBy(How = How.XPath, Using = "//a[@class='btn domain-select-new-btn']")]
        public IWebElement HostingUI_AddNewDomainToCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Purchase a new domain')]")]
        public IWebElement HostingUI_PurchaseNewDomainBtn { get; set; }

        // Common to SharedUI, VpsUI, ResellerUI, DedicatedUI - Use a domain I own with Namecheap
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Use a domain I own with Namecheap')]")]
        public IWebElement HostingUI_DomainInNamecheapBtn { get; set; }

        // Common to SharedUI, VpsUI, ResellerUI, DedicatedUI - Use a domain I own with Namecheap
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Transfer my existing domain to Namecheap')]")]
        public IWebElement HostingUI_TransferDomainToNamecheapBtn { get; set; }

        // Common to SharedUI, VpsUI, ResellerUI, DedicatedUI - Use a domain I own with Namecheap
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Use a domain I own from another registrar')]")]
        public IWebElement HostingUI_DomainFromAnotherRegistrarBtn { get; set; }

        // Shared Hosting

        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_valuepricenew_productAddToCartFieldset']/button")]
        public IWebElement SharedUI_AddToCartBtn { get; set; }
                
        [FindsBy(How = How.XPath, Using = ".//*[@class='grid-col one-quarter']/div[1]/div[1]/p[1]")]
        public IWebElement SharedUI_ConfirmOrderBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[contains(@class,'sticky')]/div[1]/p[1]/a")]
        public IWebElement NewUserSharedUI_ConfirmOrderBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[contains(@class,'cart summary')]/div[2]/div[1]/div")]
        public IWebElement SharedUI_OrderSummaryTxt { get; set; }
               

        // Reseller Hosting

        [FindsBy(How = How.XPath, Using = "//div[@class='valueprice']/fieldset[1]/button")]
        public IWebElement ResellerUI_AddtoCartBtn { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@class='four-cols']/input[1]")]
        public IWebElement ResellerUI_DomainInputTxt { get; set; }
        
        [FindsBy(How = How.XPath, Using = ".//*[contains(@class,'one-quarter')]/div/div[1]/p[1]")]
        public IWebElement ResellerUI_ConfirmOrderBtn { get; set; }

        // VPS Hosting 

        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_ctl041_productAddToCartFieldset']/button")]
        public IWebElement VpsUI_LiteAddtoCartBtn { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input[@class='domain-select-entry']")]
        public IWebElement VpsUI_DomainInputTxt { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='domain-new-search']/div[3]/a")]
        public IWebElement VpsUI_AddNewDomainToCartBtn { get; set; }

        /* [FindsBy(How = How.XPath, Using = ".//*[@id='btnViewCart']")]
        public IWebElement VpsUI_ConfigAddToCartBtn { get; set; } */
        
        // Dedicated Servers

        [FindsBy(How = How.XPath, Using = "//a[@href='/cart/addtocart.aspx?producttype=hosting&product=xeon-e3-1240-v3-8-1tb&action=purchase&period=1-MONTH']")]
        public IWebElement DedicatedUI_CpuOrderBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='domain-select-entry']")]
        //[FindsBy(How = How.XPath, Using = "//input[@placeholder='Enter your desired domain name']")]
        public IWebElement DedicatedUI_DomainInputTxt { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Add New Domain to Cart')]")]
        public IWebElement DedicatedUI_AddNewDomainToCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/cart/checkout/default.aspx']")]
        public IWebElement DedicatedUI_ConfirmOrderBtn { get; set; }
        
        //  [FindsBy(How = How.XPath, Using = "//a[contains(.,'I want to get a FREE .website domain')]")]
        [FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[7]/div[1]/div/div/div/a[1]")]
        public IWebElement DedicatedUI_FreeWebsiteBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='freedomaincontent']/div[1]/input")]
        public IWebElement DedicatedUI_FreeWebsiteInputTxt { get; set; }

        //   [FindsBy(How = How.XPath, Using = "//div[@class='domain-select-button']/a[1]")]
        [FindsBy(How = How.XPath, Using = "//div[@class='domain-free-new-search']/div[3]/a")]
        public IWebElement DedicatedUI_FreeWebsiteAddToCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Continue')]")]
        public IWebElement DedicatedUI_FreeWebsiteContinueBtn { get; set; }
                
        [FindsBy(How = How.XPath, Using = ".//*[contains(@class,'sticky')]/div[1]/p/a")]
        public IWebElement DedicatedUI_FreeWebsiteConfirmOrderBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='btn btn-block'][@onclick='Viewcartclick()']")]
        public IWebElement DedicatedUI_FreeWebsiteConfigContinueBtn { get; set; }
               

        // Private Email Hosting

        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_ctl03_productAddToCartFieldset']/button")]
        public IWebElement PEmailUI_PrivateAddtoCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[7]/div[1]/div/div/div/a[1]")]
        public IWebElement PEmailUI_PrivatePurchaseNewDomainBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[6]/div[1]/div[2]/ul/li/div/div[2]/div[1]/input")]
        public IWebElement PEmailUI_PrivateDomainInputTxt { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[contains(.,'Your domain is available')]")]
        public IWebElement PEmailUI_DomainiAvailableTxtBlk { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Add New Domain to Cart')]")]        
        public IWebElement PEmailUI_PrivateAddNewDomainToCartBtn { get; set; }
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_ctl04_productAddToCartFieldset']/button")]
	    public IWebElement PEmailUI_BusinessAddtoCartBtn { get; set; }
	
	    [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_home_content_page_content_left_ctl05_productAddToCartFieldset']/button")]
        public IWebElement PEmailUI_BusinessOfficeAddtoCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='div1']/div/div/ul/li/div/label[1]")]
        public IWebElement HostingUI_PE_CreateLater { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@type='search' and @data-pagemode='ExistingDomain']")]
        public IWebElement HostingUI_PE_ExistingDomainNameTxt { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='result'][1]/a[@class='select']")]
        public IWebElement HostingUI_PE_ExistingDomainSelect { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='domain-select-entry']")]
        public IWebElement HostingUI_DomainFromAnotherRegistrarTxt { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='domain-select-button']/a")]
        public IWebElement HostingUI_UseThisDomainBtn { get; set; }
    }
}

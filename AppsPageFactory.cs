using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumSupport = OpenQA.Selenium.Support.PageObjects;

namespace DomainUiLive.PageRepository.PageFactory.CMS
{
    class AppsPageFactory
    {
        public AppsPageFactory(IWebDriver driver)
        {
            SeleniumSupport.PageFactory.InitElements(driver, this);
        }

        // Apps Market Place
        [FindsBy(How = How.XPath, Using = ".//*[@id='content']/div[1]/div[2]/div[2]/div/a")] 
        public IWebElement AppsMrktPlaceUI_AddToCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Purchase a new domain')]")] 
        public IWebElement AppsMrktPlaceUI_PurchaseNewDomainBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[6]/div[1]/div[2]/ul/li/div/div[2]/div[1]/input")]
        public IWebElement AppsMrktPlaceUI_DomainInputTxt { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[6]/div[1]/div[2]/ul/li/div/div[3]/a")]
        public IWebElement AppsMrktPlaceUI_AddNewDomainToCartBtn { get; set; }
        
        [FindsBy(How = How.XPath, Using = ".//div[@id='BRANDIDENTITY']/div/div[1]/div/a/h2")]
        public IWebElement AppsMrktPlaceUI_UpliftSocialBtn { get; set; }

        [FindsBy(How = How.Id, Using = "add-to-cart")]
        public IWebElement AppsMrktPlaceUI_UpliftSocialAddToCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/cart/checkout/default.aspx']")]
        public IWebElement AppsMrktPlaceUI_UpliftSocialConfirmOrderBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='#BRANDIDENTITY']")]
        public IWebElement AppsMrktPlaceUI_BrandIdentityTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='#WEBSITE']")]
        public IWebElement AppsMrktPlaceUI_WebsiteTab { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='WEBSITE']/div/div[3]/div/a/h2")]
        public IWebElement AppsMrktPlaceUI_Canvas { get; set; }

        //Apps Invoiced


        [FindsBy(How = How.XPath, Using = ".//*[@id='content']/div[2]/div[2]/ul/li[3]/a")]
        public IWebElement AppsMrktPlaceUI_ToolsTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='TOOLS']/div//div[@class='app-grid-cell']/div//a[@class='app-link']//h2[contains(text(),'Invoiced')]")]
        public IWebElement AppsMrktPlaceUI_InvoicedLnk { get; set; }

        //Apps Weebly

        [FindsBy(How = How.XPath, Using = "//div[@id='All']/div//div[@class='app-grid-cell']/div//a[@class='app-link']//h2[contains(text(),'Weebly')]")]
        public IWebElement AppsMrktPlaceUI_WeeblyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='domain-select-options']//a[contains(text(),'Namecheap')]")]
        public IWebElement AppsMrktPlaceUI_OwnDomainBtn { get; set; }


        [FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[6]/div[1]/div[4]/ul/li/div/ul")]
        public IWebElement AppsMrktPlaceUI_DomainsResultsDiv { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[6]/div[1]/div[4]/ul/li/div/ul/li[1]/a")]
        public IWebElement AppsMrktPlaceUI_SelectDomainLnk { get; set; }



        //Apps Subscription

        [FindsBy(How = How.XPath, Using = ".//*[@id='subscription-container']/div[contains(@class,'center')]")]
        public IWebElement AppsSubsUI_FilterTxt { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='subscription-container-wrapper']/div[2]/div[1]/div[1]/div[1]")]
        public IWebElement AppsSubsUI_FilterDropDownBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='subscription-container-wrapper']/div[2]/div[1]/div[2]/div[1]")]
        public IWebElement AppsSubsUI_SortByDropDownBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='subscription-container-wrapper']/div[2]/div[1]/div[1]/div[2]/div/ul/li[1]")]
        public IWebElement AppsSubsUI_SortByDropDownAllBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='subscription-container']/div[1]/div[2]/div[2]/div/ul/li[1]")]
        public IWebElement AppsSubsUI_SortByLatestDropDownBtn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='subscription-container']/div[1]/div[2]/div[2]/div/ul/li[2]")]
        public IWebElement AppsSubsUI_SortByOldestDropDownBtn { get; set; }

        [FindsBy(How = How.LinkText, Using = "View Statements")]
        public IWebElement AppsSubsUI_ViewStatementLnk { get; set; }

        [FindsBy(How = How.LinkText, Using = "Edit payment settings")]
        public IWebElement AppsSubsUI_PaymentMethodLnk { get; set; }

        [FindsBy(How = How.LinkText, Using = "View in App Store")]
        public IWebElement AppsSubsUI_ViewAppStoreLnk { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Website")]
        public IWebElement AppsSubsUI_WebsiteLnk { get; set; }

        [FindsBy(How = How.LinkText, Using = "Support")]
        public IWebElement AppsSubsUI_SupportLnk { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='subscription-container']/div[1]")]
        public IWebElement AppsSubsUI_ContainerDiv { get; set; }

        //[FindsBy(How = How.XPath, Using = ".//*[@class='result']")]
        [FindsBy(How = How.XPath, Using = ".//*[@id='aspnetForm']/div[6]/div[1]/div[4]/ul/li/div/ul//li")]
        public IWebElement AppsMrktPlaceUI_DomainLst { get; set; }
    }
}

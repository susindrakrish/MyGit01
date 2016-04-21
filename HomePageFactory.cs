using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumSupport = OpenQA.Selenium.Support.PageObjects;

namespace DomainUiLive.PageRepository.PageFactory
{
	public class HomePageFactory 
	{ 
        private IWebDriver _driver;
		public HomePageFactory(IWebDriver driver) 
		{
            _driver = driver; 
            SeleniumSupport.PageFactory.InitElements(_driver, this);			
		}

		[FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_spanIconCart']")]
		public IWebElement CartIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='apnav']/nav/ul/li[1]/a/span")]
        public IWebElement LeftNavPanelDashboard { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='apnav']/nav/ul/li[2]/a/span")]
        public IWebElement LeftNavPanelExpiringSoon { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='apnav']/nav/ul/li[3]/a/span")]
        public IWebElement LeftNavPanelDomainList { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='apnav']/nav/ul/li[4]/a/span")]
        public IWebElement LeftNavPanelProductList { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='apnav']/nav/ul/li[4]/ul/li[1]/a")]
        public IWebElement LeftNavPanelProductListSslCert { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='apnav']/nav/ul/li[4]/ul/li[2]/a")]
        public IWebElement LeftNavPanelProductListOnepager{ get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='apnav']/nav/ul/li[5]/a")]
        public IWebElement LeftNavPanelProfile { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='apnav']/nav/ul/li[5]/ul/li[1]/a")]
        public IWebElement LeftNavPanelProfilePersonalInfo { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='apnav']/nav/ul/li[5]/ul/li[2]/a")]
        public IWebElement LeftNavPanelProfileSecurity { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='apnav']/nav/ul/li[5]/ul/li[3]/a")]
        public IWebElement LeftNavPanelProfileBilling { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='apnav']/nav/ul/li[5]/ul/li[4]/a")]
        public IWebElement LeftNavPanelProfileTools { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='footer']/div[1]/div/div[2]/p/a")]
        public IWebElement FooterButtonChatWithLivePerson { get; set; }

        //SigninUI
        [FindsBy(How = How.XPath, Using = ".//*[@id='header']/nav/div[3]/div/ul[1]/li[2]/a")]
        public IWebElement SignInUI_LinkTxt { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@title='Username']")]
        public IWebElement SignInUI_UsernameTxt { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@title='Password']")]
        public IWebElement SignInUI_PasswordTxt { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_topNavLoginLink")]
        public IWebElement SignInUI_TopNavLoginLink { get; set; }

        [FindsBy(How = How.ClassName, Using = "user-menu")]
        public IWebElement SignInUI_TopNavPanelUsername { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()[contains(.,'Sign out')]]")]
        public IWebElement SignInUI_SignOutLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Sign In")]
        public IWebElement HomePageUI_SignInLnk {get; set; }


        [FindsBy(How = How.XPath, Using = ".//*[contains(@class,'error has-close')]/p[1]/strong")]
        public IWebElement SignInUI_LoginValidationErrorTxt { get; set; }

    }
}

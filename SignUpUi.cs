using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UiTests.CMS.Smoke
{
    public class SignUpUi 
    {
        public IWebDriver _driver;
        // IWebDriver driver = new FirefoxDriver();

        //SignUpUI

        [FindsBy(How = How.XPath, Using = "//div[@class='top-hat expandable-group']/ul/li[3]/a")]
        public IWebElement UserSignUp { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='nc_username nc_username_required']")]
        public IWebElement SignupUserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='nc_password nc_password_required']")]
        public IWebElement SignupPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='nc_password_confirm nc_password_confirm_required']")]
        public IWebElement SignupConfirmPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='Email nc_email nc_email_required']")]
        public IWebElement SignupEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='nc_firstname nc_firstname_required']")]
        public IWebElement SignupFirstname { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='nc_lastname nc_lastname_required']")]
        public IWebElement SignupLastname { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='btn normal-btn nc_signup_submit']")]
        public IWebElement SignupCreateUser { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='header']/nav/div[3]/ul[1]/li[4]/a")]
        public IWebElement SignupUsernameInDashboard { get; set; }

        [FindsBy(How = How.XPath, Using = "//nav[@role='navigation']/a")]
        public IWebElement MainMenuExpandButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='dock']/div/ul/li[1]/div/ul/li[8]/a")]
        public IWebElement MainMenuManageProfile { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/myaccount/modify-profile.asp?ADDRESS.x=1&rkey=NC']")]
        public IWebElement ManageProfileManageAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@name='frmModProfile']/table[1]/tbody[1]/tr[6]/td[1]/table/tbody[1]/tr[1]/td[3]/input")]
        public IWebElement ManageAddOrganizationName { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@name='frmModProfile']/table[1]/tbody[1]/tr[6]/td[1]/table/tbody[1]/tr[2]/td[1]/input")]
        public IWebElement ManageAddStreedAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@name='frmModProfile']/table[1]/tbody[1]/tr[6]/td[1]/table/tbody[1]/tr[2]/td[2]/input")]
        public IWebElement ManageAddAddress2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@name='frmModProfile']/table[1]/tbody[1]/tr[6]/td[1]/table/tbody[1]/tr[2]/td[3]/input")]
        public IWebElement ManageAddJobTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@name='frmModProfile']/table[1]/tbody[1]/tr[6]/td[1]/table/tbody[1]/tr[3]/td[1]/input")]
        public IWebElement ManageAddCity { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@name='frmModProfile']/table[1]/tbody[1]/tr[6]/td[1]/table/tbody[1]/tr[3]/td[2]/table/tbody/tr/td[1]/input[1]")]
        public IWebElement ManageAddState { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@name='frmModProfile']/table[1]/tbody[1]/tr[6]/td[1]/table/tbody[1]/tr[3]/td[2]/table/tbody/tr/td[2]/input")]
        public IWebElement ManageAddZipcode { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@name='frmModProfile']/table[1]/tbody[1]/tr[6]/td[1]/table/tbody[1]/tr[3]/td[3]/select")]
        public IWebElement ManageAddCountryDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/table/tbody/tr/td[3]/form/table/tbody/tr[6]/td/table/tbody/tr[3]/td[3]/select/option[101]")]
        public IWebElement ManageAddCountrySelectIndia { get; set; }

        [FindsBy(How = How.Id, Using = "Phone")]
        public IWebElement ManageAddPhoneNo { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@name='frmModProfile']/table[1]/tbody[1]/tr[6]/td[1]/table/tbody[1]/tr[4]/td[2]/input")]
        public IWebElement ManageAddFaxNo { get; set; }

        [FindsBy(How = How.Name, Using = "SaveChanges")]
        public IWebElement ManageAddSaveChangesButton { get; set; }

        //SigninUI
        [FindsBy(How = How.XPath, Using = ".//*[@id='header']/nav/div[3]/div/ul[1]/li[2]/a")]
        public IWebElement SignIn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@title='Username']")]
        public IWebElement SignInUsername { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@title='Password']")]
        public IWebElement SignInPassword { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ctl00_ctl00_base_content_web_base_content_topNavLoginLink")]
        public IWebElement SignInTopNavLoginlink { get; set; }

		[FindsBy(How = How.ClassName, Using = "user-menu")]
		public IWebElement TopNavPanelUsername { get; set; }

		[FindsBy(How = How.XPath, Using = "//*[text()[contains(.,'Sign out')]]")]
		public IWebElement LinkSignOut { get; set; }
		
        public SignUpUi() { }

        public SignUpUi(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}

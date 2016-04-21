using System;
using DomainUiLive.Tools.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace UiTests.CMS.Smoke
{
    public class SignUpClass : SignUpUi
    {

        public void Signup(IWebDriver driver, string uname, String pwd, String cnfmpwd, String fname, String lname,
            String email1)
        {
            var page = new SignUpUi(driver);

            page.UserSignUp.Click();
            page.SignupUserName.SendKeys(uname);
            page.SignupPassword.SendKeys(pwd);
            page.SignupConfirmPassword.SendKeys(cnfmpwd);
            page.SignupFirstname.SendKeys(fname);
            page.SignupLastname.SendKeys(lname);
            page.SignupEmail.SendKeys(email1);
            page.SignupCreateUser.Click();
        }

        public void SignupAddAddress(
            IWebDriver driver, string uname, String pwd, String cnfmpwd,
            String fname, String lname, String email1, String organizationname,
            String streetaddress, String address2, String jobtitle, String city, String state,
            String zipcode, String phoneno, String faxno)
        {
            var page = new SignUpUi(driver);

            page.UserSignUp.Click();
            page.SignupUserName.SendKeys(uname);
            page.SignupPassword.SendKeys(pwd);
            page.SignupConfirmPassword.SendKeys(cnfmpwd);
            page.SignupFirstname.SendKeys(fname);
            page.SignupLastname.SendKeys(lname);
            page.SignupEmail.SendKeys(email1);
            page.SignupCreateUser.Click();
            page.MainMenuExpandButton.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            page.MainMenuManageProfile.Click();
            page.ManageProfileManageAddress.Click();
            page.ManageAddOrganizationName.SendKeys(organizationname);
            page.ManageAddStreedAddress.SendKeys(streetaddress);
            page.ManageAddAddress2.SendKeys(address2);
            page.ManageAddJobTitle.SendKeys(jobtitle);
            page.ManageAddCity.SendKeys(city);
            page.ManageAddState.SendKeys(state);
            page.ManageAddZipcode.SendKeys(zipcode);
            // page.ManageAdd_CountryDropdown.Click();
            // page.ManageAdd_Country_Select_India.Click();
            page.ManageAddPhoneNo.SendKeys(phoneno);
            page.ManageAddFaxNo.SendKeys(faxno);
            page.ManageAddSaveChangesButton.Click();
        }

        public static void Signin(IWebDriver driver, String signinuname, String signinpwd)
        {
            SignInInternal(driver, signinuname, signinpwd);

            if (SiteFinityHelper.ProcessPage(driver))
                SignInInternal(driver, signinuname, signinpwd);
        }

        private static void SignInInternal(IWebDriver driver, string signinuname, string signinpwd)
        {
            var page = new SignUpUi(driver);

            page.SignIn.Click();
            page.SignInUsername.SendKeys(signinuname);
            page.SignInPassword.SendKeys(signinpwd);
            page.SignInTopNavLoginlink.Click();
        }

        public static void SignOut(IWebDriver driver)
        {
			SignUpUi su = new SignUpUi(driver);
			Actions actions = new Actions(driver);
			actions.MoveToElement(su.TopNavPanelUsername).Perform();
			su.LinkSignOut.Click();
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
	        wait.Until(ExpectedConditions.UrlContains("loggedout=yes"));
        }
    }
}

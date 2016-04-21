using System;
using System.Threading;
using OpenQA.Selenium;
using DomainUiLive.PageRepository.PageFactory.CMS;
using DomainUiLive.PageRepository.PageFactory;
using OpenQA.Selenium.Interactions;

namespace DomainUiLive.PageRepository.Pages
{
    class SignInPage : HomePageFactory
    {
        CartPageFactory _cart;
        public SignInPage(IWebDriver driver) : base(driver) 
        {
            _cart = new CartPageFactory(driver); 
        }
        public void DoSignIn(String username, String password, IWebDriver driver) 
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(SignInUI_LinkTxt).Perform();
                SignInUI_UsernameTxt.SendKeys(username);
                SignInUI_PasswordTxt.SendKeys(password); 
                SignInUI_TopNavLoginLink.Click();
                Thread.Sleep(8000);
                if (!driver.Url.Contains("ap"))
                {   
                    Thread.Sleep(10000);
                }
            }
            catch(Exception ex)
            {   
                Console.WriteLine("Exception : "+ex.ToString()+Environment.NewLine+"Trace : "+ex.StackTrace);
            }
        }
    } 
}

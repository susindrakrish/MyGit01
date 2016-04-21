using System;
using OpenQA.Selenium;
using NUnit.Framework;
using DomainUiLive.Tools.Helpers;
using DomainUiLive.PageRepository.Pages;
using DomainUiLive.PageRepository.Pages.CMS;
using UiTests.Tools.FunctionalHelper;

namespace DomainUiLive.CMS.Smoke
{
    [TestFixture]

    class Security
    {
        static IWebDriver _Driver;
        SecurityPage _securityPage;
        
        [SetUp]
        public void Setup()
        {
            WebDriverHelper.Init("Chrome");
            _Driver = WebDriverHelper.Driver;
            _Driver.Manage().Window.Maximize();
            SiteHelper.SignIn(_Driver);
            _securityPage = new SecurityPage(_Driver);
        }

        [Test]
        public void SSLCertificates()
        {
            try
            {   
                _securityPage.PurchaseSSLCertificates(_Driver, UrlHelper.PageSecuritySslCertificates);
            }
            catch (Exception ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + ex.Message + Environment.NewLine  + "Inner Exception : " +ex.InnerException.ToString() + Environment.NewLine + ex.Source + Environment.NewLine + ex.StackTrace);
            }
        }

        [Test]
        public void WhoIsGuard() 
        {
            try
            {   
                String DomainName = DataHelper.GetRandomString(15) + UiConstants.TLD_COM;
                _securityPage.PurchaseWhoIsGuard(_Driver, UrlHelper.PageSecurityWhoisguard, DomainName);
            }
            catch (Exception Ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + Ex.Message + Environment.NewLine + Ex.Source + Environment.NewLine + Ex.StackTrace);
            }
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverHelper.Finalise();
            _Driver.Quit();
        }
    }
}

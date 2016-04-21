using System;
using DomainUiLive.PageRepository.Pages;
using DomainUiLive.PageRepository.Pages.CMS;
using DomainUiLive.Tools.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using UiTests.Tools.FunctionalHelper;

namespace DomainUiLive.CMS.Smoke
{
    [TestFixture]
    class AnApproachAllPaymentModes
    {
        static IWebDriver Driver;
        DomainsPage _domainsPage;

        [SetUp]
        public void Setup()
        {
            WebDriverHelper.Init("Chrome");
            Driver = WebDriverHelper.Driver;
            Driver.Manage().Window.Maximize();
            SiteHelper.SignIn(Driver);
            _domainsPage = new DomainsPage(Driver);
        }

        [Test]
        public void PurchaseDomainInThreePaymentMode()
        {
            try
            {   
                _domainsPage = new DomainsPage(Driver);
                _domainsPage.PurchaseDomainInThreePaymentMode(Driver, UrlHelper.PageDomainRegistration);
            }
            catch (Exception ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + ex.Message + Environment.NewLine + ex.Source + Environment.NewLine + ex.StackTrace);
            }
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}

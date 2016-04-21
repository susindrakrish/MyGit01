using System;
using OpenQA.Selenium;
using NUnit.Framework;
using DomainUiLive.Tools.Helpers;
using DomainUiLive.PageRepository.Pages;
using DomainUiLive.PageRepository.Pages.CMS;
using UiTests.Tools.FunctionalHelper;

namespace DomainUiLive.CMS.Smoke
{
    class Apps
    {
        static IWebDriver Driver;  
        AppsPage _appsPage;
        
        [SetUp]
        public void Setup()
        {
            WebDriverHelper.Init("Chrome");
            Driver = WebDriverHelper.Driver;
            Driver.Manage().Window.Maximize();
            SiteHelper.SignIn(Driver);
            _appsPage = new AppsPage(Driver);
        }

        [Test]
        public void AppsMarketPlaceBuildWebsite()
        {
            try
            {   
                String DomainName = DataHelper.GetRandomString(15) + UiConstants.TLD_BIKE;
                _appsPage.PurchaseAppsForWebsite(Driver, UrlHelper.UrlApps, DomainName);
            }
            catch (Exception Ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + Ex.Message + Environment.NewLine + Ex.Source + Environment.NewLine + Ex.StackTrace);
            }
        }
         
        [Test]
        public void AppsMarketPlaceBrandIdentity()
        {
            try
            {
                _appsPage.PurchaseAppsForBrandIdentity(Driver,  UrlHelper.UrlApps);
            }
            catch (Exception Ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + Ex.Message + Environment.NewLine + Ex.Source + Environment.NewLine + Ex.StackTrace);
            }
        }

        [Test]
        public void AppsMarketPlaceToolsInvoiced()
        {
            try
            {
                _appsPage.PurchaseAppsForToolsInvoiced(Driver, UrlHelper.UrlApps);
            }
            catch (Exception Ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + Ex.Message + Environment.NewLine + Ex.Source + Environment.NewLine + Ex.StackTrace);
            }
        }


        [Test]
        public void AppsMarketPlaceForNCDomains() 
        {
            try
            {
                _appsPage.PurchaseAppsForNCDomains(Driver, UrlHelper.UrlApps);
            }
            catch (Exception Ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + Ex.Message + Environment.NewLine + Ex.Source + Environment.NewLine + Ex.StackTrace);
            }
        }

        [Test]
        public void AppsSubscriptionLinks()
        {
            try
            {
                _appsPage.AppsSubscription(Driver, UrlHelper.UrlAppsSubscription);
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
            Driver.Quit();
        }
    }
}

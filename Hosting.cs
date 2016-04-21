using System;
using System.Windows.Forms;
using OpenQA.Selenium;
using NUnit.Framework;
using DomainUiLive.Tools.Helpers;
using DomainUiLive.PageRepository.Pages;
using DomainUiLive.PageRepository.Pages.CMS;
using UiTests.Tools.FunctionalHelper;

namespace DomainUiLive.CMS.Smoke
{
    [TestFixture]
    class Hosting
    {
        //public IWebDriver Driver = SetupClass.Driver; 
        public static IWebDriver Driver;
        HostingPage _hostingPage;
        
        [SetUp]
        public void Setup()
        {
            WebDriverHelper.Init("Chrome");
            Driver = WebDriverHelper.Driver;
            Driver.Manage().Window.Maximize();
            SiteHelper.SignIn(Driver);
            _hostingPage = new HostingPage(Driver);
        }
        
        [Test]
        public void SharedHosting()
        {
            try
            {  
                String DomainName = DataHelper.GetRandomString(13) + UiConstants.TLD_COM;
                _hostingPage.PurchaseSharedHosting(Driver, UrlHelper.PageHostingShared, DomainName, 2);
            }
            catch (Exception Ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + Ex.Message + Environment.NewLine + Ex.Source + Environment.NewLine + Ex.StackTrace);
            } 
        }

        [Test]
        public void ResellerHosting()
        {
            try
            {   
                String DomainName = DataHelper.GetRandomString(15) + UiConstants.TLD_COM;
                _hostingPage.PurchaseReSellerHosting(Driver, UrlHelper.PageHostingReseller, DomainName);
            }
            catch (Exception Ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + Ex.Message + Environment.NewLine + Ex.Source + Environment.NewLine + Ex.StackTrace);
            }            
        }

        [Test]
        public void VPSHosting()
        {
            try
            {   
                String DomainName = DataHelper.GetRandomString(10) + UiConstants.TLD_COM;
                _hostingPage.PurchaseVPSHosting(Driver, UrlHelper.PageHostingVps, DomainName);
            }
            catch (Exception Ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + Ex.Message + Environment.NewLine + Ex.Source + Environment.NewLine + Ex.StackTrace);
            }  
        }

        [Test]
        public void DedicatedServersHosting()
        {
            try
            {   
                String DomainName = DataHelper.GetRandomAlphabets(10) + UiConstants.TLD_COM;
                _hostingPage.PurchaseDedicatedServers(Driver, UrlHelper.PageHostingDedicatedServers, DomainName);
            }
            catch (Exception Ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + Ex.Message + Environment.NewLine + Ex.Source + Environment.NewLine + Ex.StackTrace);
            }  
        } 

        [Test]
        public void PrivateEmailHosting()
        {
            try
            {   
                _hostingPage.PurchasePrivateEmailHosting(Driver, UrlHelper.PageHostingEmail, String.Empty); 
            }
            catch (Exception Ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + Ex.Message + Environment.NewLine + UiConstants.INNER_EXCEPTION + Ex.InnerException.ToString() + Environment.NewLine + Ex.Source + Environment.NewLine + Ex.StackTrace);
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

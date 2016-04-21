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

    public class Domains 
    {
        
        //public static IWebDriver Driver = SetupClass.Driver;

        public static IWebDriver Driver;

        DomainsPage _domainsPage;
        internal DomainsPage DomainsPage
        {
            get
            {
                return _domainsPage;
            }
             
            set
            {
                _domainsPage = value;
            }
        }

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
        public void DomainRegistration()
        { 
            try
            {   
                String DomainName = DataHelper.GetRandomString(15) + UiConstants.TLD_BIKE; 
                DomainsPage.RegisterDomain(Driver, UrlHelper.PageDomainRegistration, DomainName);                
            }
            catch (Exception ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + ex.Message + Environment.NewLine + ex.Source + Environment.NewLine + ex.StackTrace);
            }
        }
        
        [Test] 
        public void DomainTransfer() 
        {
            try
            {  
                String DomainName = "flipkart" + UiConstants.TLD_COM;
                DomainsPage.TransferDomain(Driver, UrlHelper.PageDomainTransfer, DomainName);                
            }
            catch (Exception Ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + Ex.Message + Environment.NewLine + Ex.Source + Environment.NewLine + Ex.StackTrace);
            }
        }
        
        [Test]
        public void PersonalDomain()
        { 
            try
            {   
                DomainsPage.RegisterPersonalDomain(Driver, UrlHelper.PageDomainPersonal, DataHelper.GetRandomString(5) + new Random(DateTime.Now.Millisecond).Next(1000), DataHelper.GetRandomString(7) + new Random(DateTime.Now.Second).Next(1000));
            }
            catch (Exception Ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + Ex.Message + Environment.NewLine + Ex.Source + Environment.NewLine + Ex.StackTrace);
            }
        }
                
        [Test]
        public void DomainFreeDNS()
        {
            try
            {   
                String DomainName = DataHelper.GetRandomString(8) + UiConstants.TLD_BIKE;
                DomainsPage.PurchaseFreeDNS(Driver, UrlHelper.PageDomainFreedns, DomainName );                
            }
            catch (Exception Ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + Ex.Message + Environment.NewLine + Ex.Source + Environment.NewLine + Ex.StackTrace);
            }
        }

        [Test]
        public void PremiumDomain()
        {
            try
            {
                Driver.Navigate().GoToUrl(UrlHelper.ServerCms);
                String DomainName = UiConstants.PREMIUMDOMAINNAME;
                DomainsPage = new DomainsPage(Driver);
                DomainsPage.RegisterPremiumDomain(Driver, UrlHelper.PageDomainRegistration, DomainName);
            }
            catch (Exception Ex)
            {
                Assert.Fail(UiConstants.EXCEPTION + Ex.Message + Environment.NewLine + Ex.Source + Environment.NewLine + Ex.StackTrace);
            }
        }


        [Test]
        public void PremiumDNS() 
        {
            try
            {
                Driver.Navigate().GoToUrl(UrlHelper.ServerCms);
                String DomainName = DataHelper.GetRandomString(16) + UiConstants.TLD_BIKE;
                DomainsPage = new DomainsPage(Driver);
                DomainsPage.RegisterPremiumDNS(Driver, UrlHelper.PageDomainRegistration, DomainName);
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
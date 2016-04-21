using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System.Drawing;
using System.Threading;
using NUnit.Framework;

namespace DomainUiLive.Tools.Helpers
{
    public static class WebDriverHelper
    {
		private static readonly TimeSpan TimeOut = TimeSpan.FromMinutes(2);
	    public static IWebDriver Driver { get; set; }
        private static readonly string ScreenPath = ConfigHelper.ScreenFolder;

        public static IWebDriver Init(string browser, string version, string platform)
        {
            var commandExecutorUri = new Uri(LoadTestHelper.SeleniumGridHubUrl);

            var desiredCapabilites = new DesiredCapabilities(browser, version, Platform.CurrentPlatform);
            desiredCapabilites.SetCapability("platform", platform);

            desiredCapabilites.SetCapability("username", "thangas");
            desiredCapabilites.SetCapability("accessKey", "de965dc7-da3c-4b7a-80e0-b348372a6ecc");
            desiredCapabilites.SetCapability("name", Gallio.Framework.TestContext.CurrentContext.Test.Name);

            Driver = new RemoteWebDriver(commandExecutorUri, desiredCapabilites, TimeOut);
            Driver.Manage().Timeouts().SetScriptTimeout(TimeOut);
            Driver.Manage().Timeouts().ImplicitlyWait(TimeOut);
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeOut);
            Driver.Manage().Window.Maximize();

            return Driver;
        }

        public static void Init(string browser)
        {
            switch (browser)
            {
                case "Firefox":
                    Driver = new FirefoxDriver(new FirefoxBinary(), new FirefoxProfile(), TimeOut);
                    break;

                case "Chrome":
                    Driver = new ChromeDriver(@ConfigHelper.ChromeDriverFolder); 
                    break;

                default:
                    throw (new Exception("Driver for [" + browser + "] browser not found."));
            }

            Driver.Manage().Timeouts().SetScriptTimeout(TimeOut);
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeOut); 
            Driver.Manage().Timeouts().ImplicitlyWait(TimeOut);
            //Driver.Manage().Window.Maximize();
            Driver.Manage().Window.Size = new Size(950, 820);
        }

        public static void DeleteScreenshot()
        {
            if (string.IsNullOrEmpty(ScreenPath))
                return;

            if(Directory.Exists(ScreenPath))
                Directory.Delete(ScreenPath, true);
        }

        public static void CreateScreenshot(string funcName)
        {
            try
            {
                if (string.IsNullOrEmpty(ScreenPath))
                    return;
                
                string fileName = ScreenPath + "\\" + funcName + DateTime.Now.ToString("_yyyy-MM-dd-hhmm-ss") + ".png";

                if (!Directory.Exists(ScreenPath))
                    Directory.CreateDirectory(ScreenPath);

                ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(@fileName, System.Drawing.Imaging.ImageFormat.Png);

            }
            catch (Exception e)
            {
                var exc = e.Message;
            }
        }

        public static void Finalise()
        {
            if (TestContext.CurrentContext.Result.Status == TestStatus.Failed)
            {
                CreateScreenshot(TestContext.CurrentContext.Test.Name);
            }
        }

        public static void Sleep(int sec)
        {
            Thread.Sleep(TimeSpan.FromSeconds(sec));
        }


        public static void ExecuteJavaScript(IWebDriver driver, string javaScript, IWebElement args = null)
        {
            var je = (IJavaScriptExecutor)driver;
            je.ExecuteScript(javaScript, args);
        }
    }
}

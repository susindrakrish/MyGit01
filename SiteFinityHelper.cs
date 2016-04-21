using OpenQA.Selenium;

namespace DomainUiLive.Tools.Helpers
{
    public static class SiteFinityHelper
    {
        public static int Cnt = 0;

		public static void GoToCms(IWebDriver driver)
		{
			driver.Navigate().GoToUrl(UrlHelper.ServerCms);
			ProcessPage(driver);
		}

        public static bool ProcessPage(IWebDriver driver)
        {
            var searchString = "To proceed with your evaluation";

            if (driver.PageSource.ToLower().Contains(searchString.ToLower()))
            {
                //Driver.Navigate().Refresh();
                //((IJavaScriptExecutor) Driver).ExecuteScript("javascript:reloadPage();");
                UiHelper.FindElementByPartialHref(driver, "a", "javascript:reloadPage()").Click();
                Cnt++;

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
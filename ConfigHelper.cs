using System.Configuration;

namespace DomainUiLive.Tools.Helpers
{
    public static class ConfigHelper
	{
        static ConfigHelper()
        {
            MainUrl = ConfigurationManager.AppSettings["MainUrl"];
            СlientIp = ConfigurationManager.AppSettings["ClientIP"];

            UserName = ConfigurationManager.AppSettings["UserName"];
            Password = ConfigurationManager.AppSettings["Password"]; 

            DomainName = ConfigurationManager.AppSettings["DomainName"];
            SPeSubscriptionId = ConfigurationManager.AppSettings["PeSubscriptionId"];
            SSslCertId = ConfigurationManager.AppSettings["SslCertId"];

            PayPalUrl = ConfigurationManager.AppSettings["PayPalUrl"];
            PayPalEmail = ConfigurationManager.AppSettings["PayPalEmail"];
            PayPalPassword = ConfigurationManager.AppSettings["PayPalPassword"];
            PaymentMethod = ConfigurationManager.AppSettings["PaymentMethod"];

            ScreenFolder = ConfigurationManager.AppSettings["ScreenFolder"];
            ChromeDriverFolder = ConfigurationManager.AppSettings["ChromeDriverFolder"];

            //Add New Card
            AddNewCard = ConfigurationManager.AppSettings["AddNewCard"];
            //New Card Details
            NameOnCard = ConfigurationManager.AppSettings["NameOnCard"];
            CardNumber = ConfigurationManager.AppSettings["CardNumber"];
            CardCVV2 = ConfigurationManager.AppSettings["CardCVV2"];
            CardExpiryMonth = ConfigurationManager.AppSettings["CardExpiryMonth"];
            CardExpiryYear = ConfigurationManager.AppSettings["CardExpiryYear"];


            // Is Environmet FB or SB/PROD
            IsFeatureBranch = MainUrl.ToLower().Contains("branches");

            PeSubscriptionId = -1;

            if (!string.IsNullOrEmpty(SPeSubscriptionId))
                PeSubscriptionId = int.Parse(SPeSubscriptionId);

            if (!string.IsNullOrEmpty(SPeSubscriptionId))
                SslCertId = int.Parse(SSslCertId);
        }

        public static string MainUrl { get; private set; }
		public static string СlientIp { get; private set; }
		public static string UserName { get; private set; }
		public static string Password { get; private set; }
		public static string DomainName { get; private set; }
		public static string SPeSubscriptionId { get; private set; }
        public static int PeSubscriptionId { get; private set; }
        public static string PayPalUrl { get; private set; }
		public static string PayPalEmail { get; private set; }
		public static string PayPalPassword { get; private set; }
		public static string ScreenFolder { get; private set; }
		public static bool IsFeatureBranch { get; private set; }
        public static string SSslCertId { get; private set; }
        public static int SslCertId { get; private set; }

        //AddNewCard
        public static string AddNewCard { get; private set; }
        //New Card Details
        public static string NameOnCard { get; private set; }
        public static string CardNumber { get; private set; }
        public static string CardCVV2 { get; private set; }
        public static string CardExpiryMonth { get; private set; }
        public static string CardExpiryYear { get; private set; }
        public static string PaymentMethod { get; private set; }
        public static string ChromeDriverFolder { get; private set; }

    }
}

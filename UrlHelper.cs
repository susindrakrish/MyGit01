using System;

namespace DomainUiLive.Tools.Helpers
{
    public static class UrlHelper  
    {
		public static String ServerPrefix = "";  
		public static String ApPrefix = "ap.";
		public static String ManagePrefix = "manage."; 
		public static String HttpPrefix = "http://";
		public static String HttpsPrefix = "https://"; 
		public static string MainUrl = ConfigHelper.MainUrl;
	    public static String ServerCms = HttpPrefix + ServerPrefix + MainUrl + "/";
        public static String ServerManage = HttpPrefix + ManagePrefix + ServerPrefix + MainUrl + "/";

        public static String UrlDomain = ServerCms + "domains/";
        public static String UrlHosting = ServerCms + "hosting/";
        public static String UrlSecurity = ServerCms + "security/";
		public static String UrlMyAccount = ServerCms + "myaccount/";
	    public static String UrlSignOut = UrlMyAccount + "signout";
        public static String UrlApps = ServerCms + "apps/"; 
        public static String UrlMyaccount = ServerManage + "myaccount/"; 
        
		// domain
        public static String PageDomainRegistration = UrlDomain + "registration.aspx";
        public static String PageDomainTransfer = UrlDomain + "transfer.aspx";
        public static String PageDomainPersonal = UrlDomain + "personal.aspx";
        public static String PageDomainWhois = UrlDomain + "whois.aspx";
        public static String PageDomainFreedns = UrlDomain + "freedns.aspx";

		// hosting
        public static String PageHostingShared = UrlHosting + "shared.aspx";
        public static String PageHostingDedicatedServers = UrlHosting + "dedicated-servers.aspx";
        public static String PageHostingEmail = UrlHosting + "email.aspx"; 
        public static String PageHostingReseller = UrlHosting + "reseller.aspx";
        public static String PageHostingVps = UrlHosting + "vps.aspx";

        public static String PageSecurityWhoisguard = UrlSecurity + "whoisguard.aspx";
        public static String PageSecuritySslCertificates = UrlSecurity + "ssl-certificates.aspx";
        public static String PageSecurityPremiumDNS = UrlSecurity + "premiumdns.aspx";
        //public static String PageMyaccountIndex = UrlMyaccount + "index.asp";

        //Apps
        public static String UrlAppsSubscription = UrlApps + "subscriptions";


        // AP --------------------------------------------------------------------------------------------------------------
        public static String UrlAp = HttpsPrefix + ApPrefix + ServerPrefix + MainUrl;        
		public static String PageApManageDomain = UrlAp + "/Domains/DomainControlPanel/";
        public static String PageApPrivateEmail = UrlAp + "/Domains/PrivateEmail/";
        public static String PageApDomainList = UrlAp + "/Domains/DomainList";
		public static String PageApHosting = UrlAp + "/Hosting/Index";
		public static String PageApSSL = UrlAp + "/ProductList/SslCertificates";
		public static String Apps = "apps/";
		public static String PageProfilePersonalInfo = UrlAp + "/Profile/Info";
		public static String PageProfileTools = UrlAp + "/Profile/Tools";
	    public static String PageDomainsContactsSettings = PageProfileTools + "/DomainContactsSettings";
        public static String PageProfileSecurity = UrlAp + "/profile/security";
		public static String PageProfileBilling = UrlAp + "/Profile/Billing";
		public static String LinkResendVerificationEmail = UrlAp + "/profile/resendverification";
		public static String PageProfileSecurityAlerstList = PageProfileSecurity + "/alerts/list";
		public static String PageProfileToolsAffiliate = PageProfileTools + "/Affiliate";
		public static String PageProfileBillingAffiliateEarnings = UrlAp + "/Profile/billing/AffiliateEarnings";
		public static String PageProfileBillingOrders = UrlAp + "/profile/billing/orders";
		public static String PageProfileBillingTransactions = UrlAp + "/profile/billing/transactions";
        public static String PageApDashboard = UrlAp + "/dashboard";                
        public static String PageApInbox = PageApDashboard + "/messages/inbox/";    
        public static String PageProfileSecurity2FAManage = PageProfileSecurity + "/twofa/manage";
        public static String PageProfileSecurity2FAAdd = PageProfileSecurity + "/twofa/add";
		public static String PageMyaccountIndex = UrlMyaccount + "index.asp";
	    public static String SupportLink = "https://www.namecheap.com/support/";
                
        // Order Page URL
        public static String CartCheckout = "/cart/checkout/";
		
				
		public static string GetDomainControlPanelPage(string domainName) 
		{
			return UrlAp + "/Domains/DomainControlPanel/" + domainName;
		}

        public static string GetSubscriptionPage(int subscriptionId)
        {
			return UrlAp + "/Domains/PrivateEmail/" + subscriptionId;
        } 

	    public static string GetUpgradeSubscriptionPage(int subscriptionId)
	    {
            return GetSubscriptionPage(subscriptionId) + "/UpgradeSubscription";
	    }
         
        public static string GetSubscriptionAddYesrsPage(int subscriptionId)
        {
            return GetSubscriptionPage(subscriptionId) + "/1/false/1/Renew";
        }

        public static string GetDomainManagePageUrl(string domainName)
        {
            return PageApManageDomain + domainName + "/domain";
        }

	    public static string GetManageHostRecordsPageUrl(string domainName)
	    {
			return UrlAp + "/domains/dns/managehostrecords/" + domainName + "/advancedns";
	    }

	    public static string GetBuyMailboxPage(int subscriptionId, string subscriptionType)
	    {
			return UrlAp + "/Domains/PrivateEmail/" + subscriptionId + "/ox-" + subscriptionType + "/PurchaseMoreMailboxes";
	    }
    }
}

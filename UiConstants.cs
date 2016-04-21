using System;

namespace DomainUiLive.Tools.Helpers
{  
    class UiConstants
    {
        // Sauce Labs Credentials
        public static String SAUCELABS_USERNAME = "enyeskay";
        public static String SAUCELABS_ACCESSKEY = "0f5b734f-a7c9-4757-bd04-04ff8615b4f0";
        public static String CMDEXECUTOR_URI = "http://ondemand.saucelabs.com/wd/hub";

        // Common Constants 
        public static String USERNAME = "username"; 
        public static String PASSWORD = "password";  
        public static String PLATFORM = "platform";
        public static String ACCESSKEY = "accessKey";
        public static String NAME = "name";
        public static String SIGNIN_USER = "automatednc";
        public static String SIGNIN_PASSWORD = "automatednc";
        public static String DOMAIN_FNAME = "Susindra";
        public static String DOMAIN_LNAME = "Krishnaa";
        public static String EXCEPTION = "Exception : ";
        public static String INNER_EXCEPTION = "Inner Exception : ";
        public static String STACK_TRACE = "Stack Trace : ";
        public static String SANDBOX = "sandbox"; 
        public static String TLD_COM = ".com";
        public static String TLD_NET = ".net";
        public static String TLD_BIKE = ".bike";
        public static String ORDER_REVIEW = "Order Review";
        public static String VPS_XEN_LITE = "VPS Xen Lite";
        public static String POSITIVE_SSL = "PositiveSSL";
        public static String PURCHASE_SUMMARY = "Purchase Summary";
        public static String DOMAIN_REGISTRATION = "Domain Registration";
        public static String DOMAIN_TRANSFER = "Domain Transfer";
        public static String LASTLOGGED = "Last logged in";
        public static String DEDICATED_SERVERS = "DedicatedServers";
        public static String BRANCHES = "branches";
        public static String EXPIRED = "EXPIRED";
        public static String EXPIREDSTATUS = "Private Email Expired and Not Allowed to Renew/AddYears";
        public static String GRACE = "GRACE";

        //PE_Types

        public static String PEH_TYPE = "Private";
        //public static String PEH_TYPE = "Business";
        //public static String PEH_TYPE = "Business Office";

        public static String PEH_TYPE_DOMAIN = "PurchaseNewDomain";
        //public static String PEH_TYPE_DOMAIN = "DomainInNamecheap";

        public static String PEH_TYPE_PRIVATE = "Private";
        public static String PEH_TYPE_BUSINESS = "Business";
        public static String PEH_TYPE_BUSINESSOFFICE = "Business Office";

        //PE_Types - Domain From

        public static String PEH_TYPE_DOMAINFROM = "PurchaseNewDomain";
        public static String PEH_TYPE_DOMAININCART = "DomainInCart";
        public static String PEH_TYPE_PURCHASENEWDOMAIN = "PurchaseNewDomain";
        public static String PEH_TYPE_DOMAININNAMECHEAP = "DomainInNamecheap";
        public static String PEH_TYPE_DOMAINTONAMECHEAP = "TransferDomainToNamecheap ";
        public static String PEH_TYPE_DOMAINFROMANOTHERREGISTRAR = "DomainFromAnotherRegistrar";
                
        public static String MARKED_AS_READ = "marked as read";
        public static String MARKED_AS_UNREAD = "marked as unread";
        public static String MARKED_AS_SAVED = "saved";
        public static String REMOVED = "removed";

        public static String OFF = "OFF";
        public static String ON = "ON";
        public static String HELLO = "Hello";
        public static String LASTLOGIN = "Last logged in";
        public static String ACCOUNT_BALANCE = "Account Balance";
        public static String INBOX = "Inbox";
        public static String INBOX_INTRO_MESSAGE = "This page contains messages from Namecheap regarding your account and other services.";
        public static String INBOX_SEARCH_KEY = "Order Summary"; //Search Key for Inbox Search Filter
        public static String DATE_FROM = "12/12/2015"; //mm/dd/yyyy
        public static String DATE_TO = "12/21/2015"; //mm/dd/yyyy
        public static String NO_OF_ITEMS_PER_PAGE = "25";
        public static Char DELIMITER = ' ';         

        public static String PAYPAL = "PayPal";
        public static String ACCOUNTFUNDS = "Account Balance";

        public static String TEST_NOTAPPLICABLE = "This test is not applicable for production as it involve purchase";

        // PE - Dashboard

        public static String DASHBOARDUI_PRODUCT_XPATH = ".//*[@class='responsive-tooltip ng-scope']";
        public static Int32 DASHBOARDUI_PRODUCT_LIMIT = 5;
        public static String DASHBOARDUI_PRODUCT_ROW = "//table/tbody[2]/tr";
        public static String DASHBOARDUI_DOMAINNAME_XPATH = "/td[1]/p[1]/strong";
        public static String DASHBOARDUI_PRODUCTICON_XPATH = "/td[2]/div";
        public static String DASHBOARDUI_PRODUCT_TOOLDOWN_XPATH = ".//div[starts-with(@id,'tip-')]";

        public static String EMAIL_ICON_CLASS = "icon-email";
        public static String TOOLDOWN_ID = ".//div[starts-with(@id,'tip-')][2]";
        public static String ATTRIBUTE_ID = "id";
        public static String TOOLDOWN_TIP_0 = "tip-0";
        public static String TOOLDOWN_PRODUCT_NAME = "/div/ul[1]/li[1]/strong";
        public static String TOOLDOWN_PRODUCT_STATUS = "/div/ul[1]/li[2]/span";
        public static String TOOLDOWN_PRODUCT_EXPIRATION = "/div/ul[1]/li[3]/span";
        public static String DASHBOARD_PRODUCTICON_XPATH = "/a[starts-with(@class,'tooltip-toggle')]";
        public static String MAILBOX_PASSWORD = "123456789";
        
        public static String PRIVATEEMAIL = "Private Email";
        public static String PRIVATEEMAIL_SUBSCRIPTION = "Private Email Subscription";
        public static String BUSINESSEMAIL = "Business Email";
        public static String BUSINESSEMAIL_SUBSCRIPTION = "Business Email Subscription";
        public static String BUSINESSOFFICEEMAIL = "Business Office Email";
        public static String BUSINESSOFFICEEMAIL_SUBSCRIPTION = "Business Office Email Subscription";

        public static String DASHBOARD_TOOLDOWN_PRODUCTNAME = "ProductName";
        public static String DASHBOARD_TOOLDOWN_PRODUCTSTATUS = "ProductStatus";
        public static String DASHBOARD_TOOLDOWN_PRODUCTEXPIRATION = "ProductExpiration";
        public static String ENABLE = "ENABLE";

        //Premium Domain Name
        public static String PREMIUMDOMAINNAME = "ijm"; //cab //ncv
        public static String PREMIUMDOMAINDIV = ".//li[contains(@class,'register-premium-domain')]";}
}

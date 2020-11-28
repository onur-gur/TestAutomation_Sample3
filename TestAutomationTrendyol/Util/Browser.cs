using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace TestAutomationTrendyolUiTest.Util
{
    public class Browser
    {
        public IWebDriver webDriver;

        public IWebDriver SetupChromeDriver(string driver)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArguments("test-type");
            options.AddArguments("disable-popup-blocking");
            options.AddArguments("ignore-certificate-errors");
            options.AddArguments("disable-translate");
            options.AddArguments("disable-automatic-password-saving");
            options.AddArguments("allow-silent-push");
            options.AddArguments("disable-infobars");
            options.AddArguments("disable-notifications");
            options.AddAdditionalCapability("useAutomationExtension", false);
            webDriver = new ChromeDriver(driver, options);
            return webDriver;
        }

        public IWebDriver SetupFirefoxDriver(string driver)
        {
            webDriver = new FirefoxDriver(driver);
            return webDriver;
        }

        public IWebDriver SetupInternetExplorer(string driver)
        {
            webDriver = new InternetExplorerDriver(driver);
            return webDriver;
        }
    }
}

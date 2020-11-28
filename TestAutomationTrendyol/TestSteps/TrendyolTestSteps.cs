using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;
using TestAutomationTrendyolUiTest.PageModel;
using TestAutomationTrendyolUiTest.Util;

namespace TestAutomationTrendyolUiTest.TestSteps
{
    [Binding, Scope(Feature = "Trendyol")]
    public class TrendyolTestSteps
    {
        public static IWebDriver WebDriver { get; set; }
        public BasePage basePage;
        public LoginPage loginPage;
        public BoutiquePage boutiquePage;
        public ProductPage productPage;
        public Browser browser;
        string driverPath = String.Empty;

        public TrendyolTestSteps()
        {
            driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            browser = new Browser();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriver.Quit();
        }

        [StepDefinition("'(.*)' browser açlır")]
        public void OpenBrowser(string genericDriver)
        {
            switch (genericDriver)
            {
                case "Chrome":
                    WebDriver = browser.SetupChromeDriver(driverPath);
                    break;
                case "Firefox":
                    WebDriver = browser.SetupFirefoxDriver(driverPath);
                    break;
                case "InternetExplorer":
                    WebDriver = browser.SetupInternetExplorer(driverPath);
                    break;
            }
            loginPage = new LoginPage(WebDriver);
            basePage = new BasePage(WebDriver);
            boutiquePage = new BoutiquePage(WebDriver);
            productPage = new ProductPage(WebDriver);
        }

        [StepDefinition("'(.*)' sitesine gidilir")]
        public void OpenTrendyol(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        [StepDefinition("Pop kapatılır")]
        public void ClosePopup()
        {
            loginPage.CloseThePopup();
            string currentUrl = basePage.GetCurrentUrl();
            if (!currentUrl.Contains("trendyol.com"))
            {
                Console.WriteLine("trendyol sayfası açılmadı!");
            }
        }

        [StepDefinition("Giriş Yap butonuna tıklanır")]
        public void ClickLoginIcon()
        {
            loginPage.ClickToLogin();
            string currentUrl = basePage.GetCurrentUrl();
            if (!currentUrl.Contains("trendyol.com/giris"))
            {
                Console.WriteLine("trendyol login sayfası açılmadı!");
            }
        }

        [StepDefinition("Email adresi '(.*)' girilir")]
        public void SetEmail(string email)
        {
            loginPage.SetEmail(email);
        }

        [StepDefinition("Şifre '(.*)' girilir")]
        public void SetPassword(string password)
        {
            loginPage.SetPassword(password);
        }

        [StepDefinition("Giriş Yap butonuna tıklanır ve login olunur")]
        public void ClickSubmitLogin()
        {
            loginPage.ClickSubmitLogin();
        }

        [StepDefinition("Gelen Popup kapatılır")]
        public void ClosePopupWindow()
        {
            boutiquePage.ClosePopupWindow();
            string currentUrl = basePage.GetCurrentUrl();
            if (!currentUrl.Contains("trendyol.com/butik/liste/"))
            {
                Console.WriteLine("trendyol ana sayfası açılmadı!");
            }
        }

        [StepDefinition("Kategorilere tıklanarak butiklerin yüklendiği kontrol edilir")]
        public void CheckCategories()
        {
            boutiquePage.CheckCategories();
        }

        [StepDefinition("Rastgele kategorilere tıklanır")]
        public void ClickRandomCategory()
        {
            boutiquePage.ClickRandomCategory();
        }

        [StepDefinition("Rastgele butiğe tıklanarak ürünlerin görselleri kontrol edilir")]
        public void CheckRandomBoutiqueProducts()
        {
            productPage.CheckProduct();
        }

        [StepDefinition("Rastgele ürüne tıklanır")]
        public void ClickRandomProduct()
        {
            productPage.ClickRandomProduct();
        }

        [StepDefinition("Ürün sepete eklenir")]
        public void ClickAddToBasket()
        {
            productPage.ClickAddToBasket();
        }

    }
}

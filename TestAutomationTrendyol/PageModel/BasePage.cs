using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationTrendyolUiTest.PageModel
{
    public class BasePage
    {
        private IWebDriver webDriver;

        public BasePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public void ClickElement(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(7));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            element.Click();
        }

        public void SetText(IWebElement element, string text)
        {
            WebDriverWait wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            element.SendKeys(text);
            element.SendKeys(Keys.Tab);
        }

        public void HoverElement(IWebElement element)
        {
            Actions action = new Actions(this.webDriver);
            action.MoveToElement(element).Build().Perform();
        }

        public string GetCurrentUrl()
        {
            return this.webDriver.Url;
        }


    }
}

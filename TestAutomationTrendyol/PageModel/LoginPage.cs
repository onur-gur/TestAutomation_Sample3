using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationTrendyolUiTest.PageModel
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        [FindsBy(How = How.Id, Using = "accountBtn")]
        public IWebElement btnLogin;

        [FindsBy(How = How.XPath, Using = "//a[@title='Close']")]
        public IWebElement btnClosePopup;

        [FindsBy(How = How.XPath, Using = "//input[@id='login-email']")]
        public IWebElement txtEmail;

        [FindsBy(How = How.XPath, Using = "//input[@id='login-password-input']")]
        public IWebElement txtPasword;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'submit')]")]
        public IWebElement btnSubmit;


        public void ClickToLogin()
        {
            ClickElement(btnLogin);
        }

        public void CloseThePopup()
        {
            try
            {
                ClickElement(btnClosePopup);
            }
            catch
            {
            }
        }

        public void SetEmail(string value)
        {
            SetText(txtEmail, value);
        }

        public void SetPassword(string value)
        {
            SetText(txtPasword, value);
        }

        public void ClickSubmitLogin()
        {
            ClickElement(btnSubmit);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestAutomationTrendyolUiTest.PageModel
{
    public class BoutiquePage : BasePage
    {
        private IWebDriver webDriver;

        public BoutiquePage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        [FindsBy(How = How.XPath, Using = "//*[@class='main-nav']/li")]
        public IList<IWebElement> lblCategories;

        [FindsBy(How = How.XPath, Using = "//*[@class='modal-close']")]
        public IWebElement btnPopupWindow;

        [FindsBy(How = How.XPath, Using = "//article[@class='component-item']/a/summary/span")]
        public IList<IWebElement> boutiqueList;

        public void CheckCategories()
        {
            for (int i = 0; i < lblCategories.Count; i++)
            {
                if (!lblCategories[i].Displayed)
                {
                    string boutiqueName = lblCategories[i].Text;
                    Console.WriteLine(boutiqueName + " kategorisi yüklenmedi");
                }
                ClickElement(lblCategories[i]);
                CheckBoutiques();
            }
        }

        public void ClickRandomCategory()
        {
            Random rnd = new Random();
            int randomCategoryNumber = rnd.Next(1,lblCategories.Count-1);
            ClickElement(lblCategories[randomCategoryNumber]);
        }

        public void CheckBoutiques()
        {
            for (int i = 0; i < boutiqueList.Count; i++)
            {
                IWebElement boutique = boutiqueList[i];
                if (!boutique.Displayed)
                {
                    string boutiqueName = boutique.Text;
                    Console.WriteLine(boutiqueName + " isimli butik yüklenemedi!");
                }
            }
        }

        public void ClosePopupWindow()
        {
            try
            {
                ClickElement(btnPopupWindow);
            }
            catch
            {
            }
        }
    }
}

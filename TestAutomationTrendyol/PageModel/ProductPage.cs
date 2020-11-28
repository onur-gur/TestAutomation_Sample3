using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestAutomationTrendyolUiTest.PageModel
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//article[@class='component-item']")]
        public IList<IWebElement> boutiqueList;

        [FindsBy(How = How.XPath, Using = "//*[@class='boutique-product']")]
        public IList<IWebElement> productList;

        [FindsBy(How = How.XPath, Using = "//*[@class='boutique-product']/a/div[3]//div/span[@class='name']")]
        public IList<IWebElement> productNames;

        [FindsBy(How = How.XPath, Using = "//button[@class='pr-in-btn add-to-bs']")]
        public IWebElement btnAddToBasket;

        public void ClickRandomBoutique()
        {
            Random rnd = new Random();
            int randomBoutique = rnd.Next(1,boutiqueList.Count-1);
            ClickElement(boutiqueList[randomBoutique]);
        }
        
        public void CheckProduct()
        {
            ClickRandomBoutique();
            for (int i = 0; i < productList.Count; i++)
            {
                IWebElement product = productList[i];
                if (!product.Displayed)
                {
                    string productName = productNames[i].Text;
                    Console.WriteLine(productName + " ürün görseli yüklenmedi");
                }
            }
        }

        public void ClickRandomProduct()
        {
            Random rnd = new Random();
            int randomProduct = rnd.Next(1,productNames.Count-1);
            ClickElement(productNames[randomProduct]);
        }

        public void ClickAddToBasket()
        {
            ClickElement(btnAddToBasket);
        }
    }
}

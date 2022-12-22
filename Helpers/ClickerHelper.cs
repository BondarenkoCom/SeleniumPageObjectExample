using OpenQA.Selenium;
using PageObjectPatternSelenium.Assembly;
using System.Threading;

namespace PageObjectPatternSelenium.Helpers
{
    public class PageActions: Browser
    {
        public void Clicker(string changeXpath)
        {
            webDriver.FindElement(By.XPath(changeXpath)).Click();
        }

        public string GetText(string XpathForCheck)
        {
            //TODO сделать удобный waiter для элементов
            var FindText = webDriver.FindElement(By.XPath(XpathForCheck));
            var result = FindText.Text;
        
            Thread.Sleep(3000);
            return result;
        }
    }
}

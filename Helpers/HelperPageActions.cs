using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectPatternSelenium.Assembly;
using System;

namespace PageObjectPatternSelenium.Helpers
{
    public class HelperPageActions : Browser
    {
        //TODO Add to all HelperSnapshot.MakeSnapshot(SnapName);

        public void Clicker(string changeXpath)
        {
            //TODO make Try Catch for catch bugs
            try
            {
              Browser.WaiterLoadPage(20);

              webDriver.FindElement(By.XPath(changeXpath)).Click();
            }
            catch(NoSuchElementException mes)
            {
              Console.WriteLine(mes);
              Assert.Fail(mes.Message);
            }
        }

        public static bool FindAndCheckExist(string Xpath ,string SnapName)
        {
            try
            {
                Browser.WaiterLoadPage(20);

                bool IsElementDisplayed = webDriver.FindElement(By.XPath(Xpath)).Displayed;
                return IsElementDisplayed;
            }
            catch(NoSuchElementException mes)
            {
                Console.WriteLine(mes);
                Assert.Fail(mes.Message);
                HelperSnapshot.MakeSnapshot(SnapName);
                return false;
            }
        }

        public string GetText(string XpathForCheck)
        {
            try
            {
                Browser.WaiterLoadPage(20);

                var FindText = webDriver.FindElement(By.XPath(XpathForCheck));
                var result = FindText.Text;

                return result;
            }
            catch(NoSuchElementException mes)
            {
                Assert.Fail(mes.Message);
                return mes.Message;
            }
        }

        public void SenderKeys(string xpathForm, string textKey)
        {
            try
            {
                Browser.WaiterLoadPage(20);

                var findForm = webDriver.FindElement(By.XPath(xpathForm));
                findForm.Clear();
                findForm.SendKeys(textKey);
            }
            catch (NoSuchElementException mes)
            {
                Assert.Fail(mes.Message);
            }
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectPatternSelenium.Assembly;
using PageObjectPatternSelenium.ChromeConstants;
using System;
using System.IO;

namespace PageObjectPatternSelenium.Helpers
{
    public class HelperPageActions : Browser
    {
        public void Clicker(string changeXpath, string SnapName)
        {
            try
            {
              Browser.WaiterLoadPage(20);

              webDriver.FindElement(By.XPath(changeXpath)).Click();
            }
            catch(NoSuchElementException mes)
            {
              Console.WriteLine(mes);
              HelperSnapshot.MakeSnapshot(SnapName);

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
                HelperSnapshot.MakeSnapshot(SnapName);
                Console.WriteLine(mes);
                Assert.Fail(mes.Message);
                return false;
            }
        }

        public static bool FindAndCheckExistFileOnMachine(string path, string SnapName)
        {
                try
                {
                    string filePath = path;
                    var checkState = File.Exists(filePath);
                    if (checkState == true)
                    {
                        try
                        {
                            File.Delete(filePath);
                        }
                        catch (Exception ex)
                        {
                            HelperSnapshot.MakeSnapshot(SnapName);
                            Console.WriteLine("error: " + ex.Message);
                        }
                    }
                    return checkState;
                }
                catch (NoSuchElementException mes)
                {
                    HelperSnapshot.MakeSnapshot(SnapName);
                    Console.WriteLine(mes);
                    Assert.Fail(mes.Message);
                    return false;
                }
        }

        public string GetText(string XpathForCheck, string SnapName)
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
                HelperSnapshot.MakeSnapshot(SnapName);
                Assert.Fail(mes.Message);
                return mes.Message;
            }
        }

        public void SenderKeys(string xpathForm, string textKey, string SnapName)
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
                HelperSnapshot.MakeSnapshot(SnapName);
                Assert.Fail(mes.Message);
            }
        }
    }
}

using OpenQA.Selenium;
using PageObjectPatternSelenium.Assembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectPatternSelenium.Helpers
{
    public class HelperExistElement : Browser
    {
        public static bool IsExistElement(string xpath)
        {
            try
            {
                webDriver.FindElement(By.XPath(xpath));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}

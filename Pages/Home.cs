using OpenQA.Selenium;
using PageObjectPatternSelenium.Assembly;
using PageObjectPatternSelenium.ChromeConstants;
using SeleniumExtras.PageObjects;
using System;

namespace PageObjectPatternSelenium.Pages
{
    public class Home
    {
        
        //Actions
        public void CheckWebSite()
        {
            //TODO сделать проверку по Assert.That
            if(Browser.Title == BrowserValues.htmlTitle)
            {
                Console.WriteLine($"Browser title is correct - {Browser.Title}\nDesign Pattern button is exist - {PageHomeForChrome.designPatternsButton}");
                //Assert.IsTrue(Browsers.Title.Equals("nopCommerce demo store"));
            }
            else
            {
                Console.WriteLine($"Browser title is not a correct - {Browser.Title}");
            }
        }

    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using PageObjectPatternSelenium.ChromeConstants;

namespace PageObjectPatternSelenium.Assembly
{
    public class Browser
    {
        public static IWebDriver webDriver;
        public static string browser = "Chrome";

        public static void Init()
        {
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
                default:
                    webDriver = new ChromeDriver();
                    break;
            }
            webDriver.Manage().Window.Maximize();

            Goto(BrowserValues.url);
            WaiterLoadPage(10);
        }

        public static string Title
        {
            get {return webDriver.Title; }
        }

        public static IWebDriver getDriver
        {
            get { return webDriver; }
        }

        public static string CheckUrl
        {
            get { return webDriver.Url; }
        }

        public static void WaiterLoadPage(int secondCount)
        {
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(secondCount);
        }

        public static void Goto(string url)
        {
            webDriver.Url = url;
        }

        public static void Close()
        {
            webDriver.Close();
        }
    }
}




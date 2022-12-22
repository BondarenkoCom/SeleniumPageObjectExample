using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjectPatternSelenium.ChromeConstants
{
    public class PageHomeForChrome
    {
        //[FindsBy(How = How.XPath, Using = "/html/body/div[1]/main/div/div[2]/h1")]
        //public IWebElement hellowWorldTextBlock;

        public static string hellowWorldTextBlock = "/html/body/div[1]/main/div/div[2]/h1";
        public static string BrokeXpath = "/html/body/div[1]/aside/div[4]/div/div/div/div[1]/a[11]/span[11]";
        public const string designPatternsButton = "/html/body/div[1]/main/div/div[2]/p[2]";
        public static string changeLanguageToRussian = "/html/body/div[1]/aside/div[4]/div/div/div/div[1]/a[8]/span[2]";
        public static string changeLanguagrToPoland = "/html/body/div[1]/aside/div[4]/div/div/div/div[1]/a[6]/span[2]";
    }
}
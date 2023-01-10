using OpenQA.Selenium;
using PageObjectPatternSelenium.Assembly;

namespace PageObjectPatternSelenium.Helpers
{
    public class HelperSnapshot : Browser
    {
        public static void MakeSnapshot(string shotName)
        {
            //TODO Make Short path ./ etc
            //TODO file config Json
            // https://metanit.com/sharp/aspnet6/6.3.php
            string pathScreensFolder = @"C:\Users\Honor\source\lessonRepo\BookPracticCsharp\PageObjectPatternSelenium\Screenshots\";

            Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
            ss.SaveAsFile(pathScreensFolder+shotName+".png", ScreenshotImageFormat.Png);
        }
    }
}

using OpenQA.Selenium;
using PageObjectPatternSelenium.Assembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectPatternSelenium.Helpers
{
    public class HelperSnapshot : Browser
    {
        public static void MakeSnapshot(string shotName)
        {
            //TODO Make Short path ./ etc

            string pathScreensFolder = @"C:\Users\Honor\source\lessonRepo\BookPracticCsharp\PageObjectPatternSelenium\Screenshots\";

            Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
            ss.SaveAsFile(pathScreensFolder+shotName+".png", ScreenshotImageFormat.Png);
        }
    }
}

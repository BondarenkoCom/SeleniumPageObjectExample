using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectPatternSelenium.ChromeConstants
{
    public class PageAuthForChrome
    {
        public static string logInButton = "/html/body/div[1]/nav/div[1]/ul/li[3]/a";
        public static string buttonLoginForReaquestToServer = "/html/body/div[1]/div/div/div/div/div[1]/div[1]/form/div[2]/div[1]/button";
        public static string formEmail =  "//*[@id=\"email\"]";
        public static string formPassword = "//*[@id=\"password\"]";

    }
}

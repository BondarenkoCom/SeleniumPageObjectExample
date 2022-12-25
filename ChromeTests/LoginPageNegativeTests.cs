using NUnit.Framework;
using PageObjectPatternSelenium.Assembly;
using PageObjectPatternSelenium.ChromeConstants;
using PageObjectPatternSelenium.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PageObjectPatternSelenium.ChromeTests
{
    [TestFixture]
    public class LoginPageNegativeTests
    {
        PageActions _pageActions = null;

        [SetUp]
        public void SetUp()
        {
            Browser.Init();
            _pageActions = new PageActions();
        }

        [TearDown]
        public void EndTest()
        {
            Browser.Close();
        }

        [Test]
        [Author("Artem Bondarenko", "BondCorporation@yandex.ru")]
        public void Test_Broke_Login_Form()
        {
            Pages.Pages.home.CheckWebSite();
            Browser.WaiterLoadPage(20);

            var buttonLogin = new PageActions();
            buttonLogin.Clicker(PageHomeForChrome.buttonLogin);

            //Thread.Sleep(4000);
            Browser.WaiterLoadPage(20);

            var LogInButtonAction = new PageActions();
            LogInButtonAction.Clicker(PageAuthForChrome.logInButton);

            //TODO Make Assert for check error in page
            Thread.Sleep(3000);
        }

    }
}

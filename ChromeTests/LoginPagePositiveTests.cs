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
    public class LoginPagePositiveTests
    {
        HelperPageActions _pageActions = null;

        [SetUp]
        public void SetUp()
        {
            Browser.Init();
            _pageActions = new HelperPageActions();

        }

        [TearDown]
        public void EndTest()
        {
            Browser.Close();
        }

        [Test]
        [Author("Artem Bondarenko", "BondCorporation@yandex.ru")]
        public void TestLoginToAccount()
        {
            Pages.Pages.home.CheckWebSite();
            Thread.Sleep(3000);

            //Step one,open page
            var buttonLogIn = new HelperPageActions();
            buttonLogIn.Clicker(PageAuthForChrome.logInButton);

            Browser.WaiterLoadPage(10);
            //Thread.Sleep(2000);

            //TODO later make read test data from SqlIte
            var emailForm = new HelperPageActions();
            emailForm.SenderKeys(PageAuthForChrome.formEmail, "something@gmail.com");

            var passwordForm = new HelperPageActions();
            passwordForm.SenderKeys(PageAuthForChrome.formPassword, "password");

            var buttonLogInForMakeRequest = new HelperPageActions();
            buttonLogInForMakeRequest.Clicker(PageAuthForChrome.buttonLoginForReaquestToServer);

            Thread.Sleep(10000);

            Assert.Multiple(() =>
            {
                //TODO check for result login
            });

        }
    }
}

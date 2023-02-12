using NUnit.Framework;
using PageObjectPatternSelenium.Assembly;
using PageObjectPatternSelenium.ChromeConstants;
using PageObjectPatternSelenium.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectPatternSelenium.ChromeTests.BaseMethods
{
    [TestFixture]
    public class LoginAuth
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

        [Test, Order(1)]
        [Parallelizable]
        [Author("Artem Bondarenko", "BondCorporation@yandex.ru")]
        public static async Task Positive_Test_Login_ToAccount()
        {
            Pages.Pages.home.CheckWebSite();
            Browser.WaiterLoadPage(10);
            string nameTest = MethodBase.GetCurrentMethod().Name;

            var buttonLogIn = new HelperPageActions();
            buttonLogIn.Clicker(PageAuthForChrome.logInButton, nameTest);

            Browser.WaiterLoadPage(10);

            //TODO later make read test data from SqlIte
            var emailForm = new HelperPageActions();
            emailForm.SenderKeys(PageAuthForChrome.formEmail, TestValues.CorrectLogin, nameTest + "_Sender_Keys_EmailForm");

            var passwordForm = new HelperPageActions();
            passwordForm.SenderKeys(PageAuthForChrome.formPassword, TestValues.CorrectPassword, nameTest + "_Sender_Keys_PasswordForm");

            var buttonLogInForMakeRequest = new HelperPageActions();
            buttonLogInForMakeRequest.Clicker(PageAuthForChrome.buttonLoginForReaquestToServer, nameTest);

            var buttonProfile = PageAuthForChrome.ProductsInProfile;

            Browser.WaiterLoadPage(10);

            Assert.Multiple(() =>
            {
                Assert.That(buttonProfile, Is.Not.Null);
                Assert.That(buttonProfile, Is.Not.Empty);
                Assert.That(HelperPageActions.FindAndCheckExist(buttonProfile, "profileAccount"), Is.True);
            });
        }

    }
}

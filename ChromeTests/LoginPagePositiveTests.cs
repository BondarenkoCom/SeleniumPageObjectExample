using NUnit.Framework;
using PageObjectPatternSelenium.Assembly;
using PageObjectPatternSelenium.ChromeConstants;
using PageObjectPatternSelenium.ChromeTests.BaseMethods;
using PageObjectPatternSelenium.Helpers;
using System;
using System.Reflection;
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

        [Test, Order(1)]
        [Parallelizable]
        [Author("Artem Bondarenko", "BondCorporation@yandex.ru")]
        public void Positive_Test_Login_ToAccount()
        {
            Pages.Pages.home.CheckWebSite();
            Browser.WaiterLoadPage(10);
            string nameTest = MethodBase.GetCurrentMethod().Name;

            var buttonLogIn = new HelperPageActions();
            buttonLogIn.Clicker(PageAuthForChrome.logInButton, nameTest);

            Browser.WaiterLoadPage(10);

            //TODO later make read test data from SqlIte
            var emailForm = new HelperPageActions();
            emailForm.SenderKeys(PageAuthForChrome.formEmail, TestValues.CorrectLogin, nameTest+"_Sender_Keys_EmailForm");

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


        [Test, Order(2)]
        public async Task Positive_Test_Demo_Button()
        {
            Pages.Pages.home.CheckWebSite();
            Browser.WaiterLoadPage(10);
            string nameTest = MethodBase.GetCurrentMethod().Name;

            await LoginAuth.Positive_Test_Login_ToAccount();

            var buttonDemo = new HelperPageActions();
            buttonDemo.Clicker(PageProfileForChrome.demoButton, nameTest);

            
            //Make Download Checker
            Thread.Sleep(10000);

            var demoButtonIsExist = PageProfileForChrome.demoButton;

            var checkIsExistDownloadFile = HelperPageActions.FindAndCheckExistFileOnMachine(
                        FilesInformation.getPdfPath, "PDF Demo Book");

            Assert.Multiple(() =>
            {
                Assert.IsTrue(checkIsExistDownloadFile);
                Assert.That(HelperPageActions.FindAndCheckExist(demoButtonIsExist, "profile Account demo button"), Is.True);
            });

            Browser.WaiterLoadPage(10);
        }

    }
}

using NUnit.Framework;
using PageObjectPatternSelenium.Assembly;
using PageObjectPatternSelenium.ChromeConstants;
using PageObjectPatternSelenium.Helpers;
using System;
using System.Threading;

namespace PageObjectPatternSelenium.ChromeTests
{
    [TestFixture]
    public class LoginPageNegativeTests
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
        //TODO make read test values from TestValues Class 
        //TODO Make more various wrong values https://www.qamadness.com/5-test-design-techniques-qa-engineers-should-know/
        [TestCase("something@gmail.com", "password")]
        [TestCase("----------------", "9999999999999")]
        public void Test_Broke_Login_Form(string WrongLogin, string WrongPassword)
        {
            Pages.Pages.home.CheckWebSite();
            Browser.WaiterLoadPage(10);

            var buttonLogIn = new HelperPageActions();
            buttonLogIn.Clicker(PageAuthForChrome.logInButton);

            Browser.WaiterLoadPage(10);

            var emailForm = new HelperPageActions();
            emailForm.SenderKeys(PageAuthForChrome.formEmail, WrongLogin);

            var passwordForm = new HelperPageActions();
            passwordForm.SenderKeys(PageAuthForChrome.formPassword, WrongPassword);

            var buttonLogInForMakeRequest = new HelperPageActions();
            buttonLogInForMakeRequest.Clicker(PageAuthForChrome.buttonLoginForReaquestToServer);
            
            var ErrrorMessageAuth = PageAuthForChrome.ErrorAuthMessage;
            
            var GetErrrorText = new HelperPageActions();
            var result = GetErrrorText.GetText(PageAuthForChrome.ErrorAuthMessage);

            Browser.WaiterLoadPage(10);
            
            Assert.Multiple(() =>
            {
                Assert.That(ErrrorMessageAuth, Is.Not.Null);
                Assert.That(ErrrorMessageAuth, Is.Not.Empty);
                Assert.That(HelperPageActions.FindAndCheckExist(ErrrorMessageAuth , "errorWindow"), Is.True);
                Assert.That(result, Does.Match("Whoops"));
            });
        }

    }
}

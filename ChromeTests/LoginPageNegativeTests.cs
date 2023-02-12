using NUnit.Framework;
using PageObjectPatternSelenium.Assembly;
using PageObjectPatternSelenium.ChromeConstants;
using PageObjectPatternSelenium.CreateTestValues;
using PageObjectPatternSelenium.Helpers;
using System;
using System.Reflection;

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
        [Parallelizable]
        [Description("Here we use technique test design 'Equivalent Class Partitioning'")]
        [TestCase("something@gmail.com", "1231")]
        [TestCase("something@gmail.com", "@#49023@")]
        [TestCase("something@gmail.com", "########")]
        [TestCase("something@gmail.com", "SELECT * FROM ")]
        [TestCase("something@gmail.com", "999999999999999999999999999999999999999999999999999999999")]
        [TestCase("something@gmail.com", "%%%/%%%")]
        [TestCase(" ", " ")]
        public void Test_Equivalent_Class(string WrongLogin, string WrongPassword)
        {
            Pages.Pages.home.CheckWebSite();
            Browser.WaiterLoadPage(10);
            string nameTest = MethodBase.GetCurrentMethod().Name;

            _pageActions.Clicker(PageAuthForChrome.logInButton, nameTest);

            Browser.WaiterLoadPage(10);

            var emailForm = new HelperPageActions();
            emailForm.SenderKeys(PageAuthForChrome.formEmail, WrongLogin, nameTest+"_Sender_Keys_EmailForm");

            var passwordForm = new HelperPageActions();
            passwordForm.SenderKeys(PageAuthForChrome.formPassword, WrongPassword, nameTest + "_Sender_Keys_PasswordForm");

            var buttonLogInForMakeRequest = new HelperPageActions();
            buttonLogInForMakeRequest.Clicker(PageAuthForChrome.buttonLoginForReaquestToServer, nameTest+"_Click_Button_Login");

            var ErrrorMessageAuth = PageAuthForChrome.ErrorAuthMessage;

            var GetErrrorText = new HelperPageActions();
            var result = GetErrrorText.GetText(PageAuthForChrome.ErrorAuthMessage, nameTest);

            Browser.WaiterLoadPage(10);

            Assert.Multiple(() =>
            {
                Assert.That(ErrrorMessageAuth, Is.Not.Null);
                Assert.That(ErrrorMessageAuth, Is.Not.Empty);
                Assert.That(HelperPageActions.FindAndCheckExist(ErrrorMessageAuth, "errorWindow"), Is.True);
                Assert.That(result, Does.Match("Whoops"));
            });
        }
        
        [Test]
        [Parallelizable]
        [Author("Artem Bondarenko", "BondCorporation@yandex.ru")]
        [TestCase("something@gmail.com", "password", Description = "Test Design - Valid group (Equivalence Partitioning)")]
        [TestCase("s@s", "password", Description = "Test Design - Invalid group (Equivalence Partitioning)")]
        [TestCase("something@gmailcom", "password", Description = "Test Design - Invalid group (Equivalence Partitioning)")]
        [TestCase("something@gmailA.com", "password", Description = "Test Design - Invalid group (Equivalence Partitioning)")]
        public void Negative_Test_Broke_Login_Form(string WrongLogin, string WrongPassword)
        {
            Pages.Pages.home.CheckWebSite();
            Browser.WaiterLoadPage(10);
            string nameTest = MethodBase.GetCurrentMethod().Name;
            _pageActions.Clicker(PageAuthForChrome.logInButton, nameTest);

            Browser.WaiterLoadPage(10);

            var emailForm = new HelperPageActions();
            emailForm.SenderKeys(PageAuthForChrome.formEmail, WrongLogin, nameTest+"_SenderKeys_EmailForm_");

            var passwordForm = new HelperPageActions();
            passwordForm.SenderKeys(PageAuthForChrome.formPassword, WrongPassword,nameTest + "_SenderKeys_PasswordForm_");

            var buttonLogInForMakeRequest = new HelperPageActions();
            buttonLogInForMakeRequest.Clicker(PageAuthForChrome.buttonLoginForReaquestToServer, nameTest);
            
            var ErrrorMessageAuth = PageAuthForChrome.ErrorAuthMessage;
            
            var GetErrrorText = new HelperPageActions();
            var result = GetErrrorText.GetText(PageAuthForChrome.ErrorAuthMessage, nameTest);

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

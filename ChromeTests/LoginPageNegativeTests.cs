using NUnit.Framework;
using PageObjectPatternSelenium.Assembly;
using PageObjectPatternSelenium.ChromeConstants;
using PageObjectPatternSelenium.Helpers;

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
        [Description("Here we use technique test design 'Equivalent Class Partitioning'")]
        [TestCase("something@gmail.com", "1231")]
        [TestCase("something@gmail.com", "@#49023@")]
        [TestCase("something@gmail.com", "########")]
        [TestCase("something@gmail.com", "SELECT * FROM ")]
        [TestCase("something@gmail.com", "0")]
        [TestCase("something@gmail.com", "999999999999999999999999999999999999999999999999999999999")]
        [TestCase("something@gmail.com", "%%%/%%%")]
        [TestCase(" ", " ")]
        [TestCase("<script>alert(«Hello, world!»)</alert>")]
        [TestCase("«»‘~!@#$%^&*()?>,./<][ /*<!—«», «${code}»;—>")]
        public void Test_Equivalent_Class(string WrongLogin, string WrongPassword)
        {
            Pages.Pages.home.CheckWebSite();
            Browser.WaiterLoadPage(10);
            string nameTest = "Test_Equivalent_Class";

            _pageActions.Clicker(PageAuthForChrome.logInButton, nameTest);

            Browser.WaiterLoadPage(10);

            var emailForm = new HelperPageActions();
            emailForm.SenderKeys(PageAuthForChrome.formEmail, WrongLogin);

            var passwordForm = new HelperPageActions();
            passwordForm.SenderKeys(PageAuthForChrome.formPassword, WrongPassword);

            var buttonLogInForMakeRequest = new HelperPageActions();
            buttonLogInForMakeRequest.Clicker(PageAuthForChrome.buttonLoginForReaquestToServer, nameTest);

            var ErrrorMessageAuth = PageAuthForChrome.ErrorAuthMessage;

            var GetErrrorText = new HelperPageActions();
            var result = GetErrrorText.GetText(PageAuthForChrome.ErrorAuthMessage);

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
        [Author("Artem Bondarenko", "BondCorporation@yandex.ru")]
        //TODO make read test values from TestValues Class 
        //TODO Make more various wrong values https://www.qamadness.com/5-test-design-techniques-qa-engineers-should-know/
        //TODO повторить техники тест дизайна и применить их в этих тестах
        [TestCase("something@gmail.com", "password")]
        [TestCase("----------------", "9999999999999")]
        public void Test_Broke_Login_Form(string WrongLogin, string WrongPassword)
        {
            Pages.Pages.home.CheckWebSite();
            Browser.WaiterLoadPage(10);
            string nameTest = "Test_Broke_Login_Form";

            _pageActions.Clicker(PageAuthForChrome.logInButton, nameTest);

            Browser.WaiterLoadPage(10);

            var emailForm = new HelperPageActions();
            emailForm.SenderKeys(PageAuthForChrome.formEmail, WrongLogin);

            var passwordForm = new HelperPageActions();
            passwordForm.SenderKeys(PageAuthForChrome.formPassword, WrongPassword);

            var buttonLogInForMakeRequest = new HelperPageActions();
            buttonLogInForMakeRequest.Clicker(PageAuthForChrome.buttonLoginForReaquestToServer, nameTest);
            
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

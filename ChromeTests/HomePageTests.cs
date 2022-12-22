using NUnit.Framework;
using PageObjectPatternSelenium.Assembly;
using PageObjectPatternSelenium.ChromeConstants;
using PageObjectPatternSelenium.Helpers;
using System;
using System.Threading;

namespace PageObjectPatternSelenium
{
    [TestFixture]
    public class ObjectPatternTests
    {
        PageActions _pageActions = null;

        [SetUp]
        public void Setup()
        {
            Browser.Init();
            _pageActions = new PageActions();
            
        }

        [TearDown]
        public void EndTest()
        {
            Browser.Close();
        }

        //TODO придумать тест который проверит что язык изменился
        [Test]
        [Author("Artem Bondarenko", "BondCorporation@yandex.ru")]
        public void TestChangeLanguageToPolski()
        {
            Pages.Pages.home.CheckWebSite();
            Thread.Sleep(3000);
                
            var buttonLang = new PageActions();
            buttonLang.Clicker(PageHomeForChrome.changeLanguagrToPoland);

            Thread.Sleep(2000);
        }

        [Test]
        [Author("Artem Bondarenko", "BondCorporation@yandex.ru")]
        public void TestChangeLanguageToRussian()
        {
            Pages.Pages.home.CheckWebSite();
            Thread.Sleep(3000);

            _pageActions.Clicker(PageHomeForChrome.changeLanguageToRussian);

            Thread.Sleep(5000);

            var result = _pageActions.GetText(PageHomeForChrome.hellowWorldTextBlock);
            
            Thread.Sleep(4000);

            Console.WriteLine(result);
            Assert.That(result, Does.Match("Hello, world! Привет!"));
        }

        [Test]
        [Ignore("special error")]
        [Author("Artem Bondarenko", "BondCorporation@yandex.ru")]
        public void TestWithError()
        {
            Pages.Pages.home.CheckWebSite();
            Thread.Sleep(3000);

            //var buttonLang = new ClickerHelper();
            //buttonLang.Clicker(XpathsForChrome.BrokeXpath);

            //какие можно сделать Assert что убедиться что язык сменился?
            Thread.Sleep(2000);
        }

    }
}
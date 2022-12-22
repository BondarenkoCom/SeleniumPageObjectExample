using PageObjectPatternSelenium.Assembly;
using SeleniumExtras.PageObjects;

namespace PageObjectPatternSelenium.Pages
{
    public static class Pages
    {
        private static T getPages<T>() where T : new()
        {
            var page= new T();
            PageFactory.InitElements(Browser.getDriver, page);
            return page;
        }

        public static Home home
        {
            get { return getPages<Home>(); }
        }
    }
}

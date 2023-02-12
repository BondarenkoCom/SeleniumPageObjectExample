using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectPatternSelenium.ChromeConstants
{
    public static class FilesInformation
    {
        public static string getPdfPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        "Downloads",
        "design-patterns-en-demo.pdf");
    }
}

using OpenQA.Selenium;
using System.Threading;

namespace Application.Tests.Mappings.ColorModal
{
    public class ColorModalActions
    {
        private static ColorModal ColorModal { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            ColorModal = new ColorModal(driver);
        }

        public static void AddColor()
        {
            ColorModal.AddColorButton.Click();
            Thread.Sleep(500);
        }

        public static void PopulateColorModal(string name)
        {
            ColorModal.ColorName.SendKeys(name);
        }
    }
}

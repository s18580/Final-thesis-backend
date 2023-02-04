using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace Application.Tests.Mappings.PaperModal
{
    public class PaperModalActions
    {
        private static PaperModal PaperModal { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            PaperModal = new PaperModal(driver);
        }

        public static void AddPaper()
        {
            PaperModal.AddPaperButton.Click();
            Thread.Sleep(500);
        }

        public static void PopulatePaperModal(string name, string type, string format, int opacity, int quantity, double pricePerKilo, string fiberDirection)
        {
            PaperModal.FiberDirectionDropdown.Click();
            IReadOnlyList<IWebElement> fiberDirections = PaperModal.DropdownElements;
            if (fiberDirections.Count != 0)
            {
                fiberDirections[0].Click();
            }

            PaperModal.PaperName.SendKeys(name);
            PaperModal.PaperType.SendKeys(type);
            PaperModal.PaperFormat.SendKeys(format);
            PaperModal.PaperOpacity.Clear();
            PaperModal.PaperOpacity.SendKeys(opacity.ToString());
            PaperModal.PaperQuantity.Clear();
            PaperModal.PaperQuantity.SendKeys(quantity.ToString());
            PaperModal.PricePerKilo.Clear();
            PaperModal.PricePerKilo.SendKeys(pricePerKilo.ToString().Replace(',', '.'));
        }
    }
}

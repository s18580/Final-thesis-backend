using OpenQA.Selenium;
using System.Threading;

namespace Application.Tests.Mappings.SupplierForm
{
    public class SupplierActions
    {
        private static SupplierForm SupplierForm { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            SupplierForm = new SupplierForm(driver);
        }

        public static void OpenRepresentativeModal()
        {
            SupplierForm.AddRepresentativeButton.Click();
            Thread.Sleep(500);
        }

        public static void OpenAddressModal()
        {
            SupplierForm.AddAddressButton.Click();
            Thread.Sleep(500);
        }

        public static void AddSupplier()
        {
            SupplierForm.AddSupplierButton.Click();
            Thread.Sleep(2000);
        }

        public static void PopulateSupplierDetails(string name, string description, string email, string phone)
        {
            SupplierForm.Name.SendKeys(name);
            SupplierForm.Email.SendKeys(email);
            SupplierForm.Phone.SendKeys(phone);
            SupplierForm.Description.SendKeys(description);
        }
    }
}

using OpenQA.Selenium;
using System.Threading;

namespace Application.Tests.Mappings.CustomerForm
{
    public class CustomerActions
    {
        private static CustomerForm CustomerForm { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            CustomerForm = new CustomerForm(driver);
        }

        public static void SetCustomerTypeOnCompany()
        {
            CustomerForm.CompanyType.Click();
            Thread.Sleep(500);
        }

        public static void SetCustomerTypeOnPerson()
        {
            CustomerForm.PersonType.Click();
            Thread.Sleep(500);
        }

        public static void OpenRepresentativeModal()
        {
            CustomerForm.AddRepresentativeButton.Click();
            Thread.Sleep(500);
        }

        public static void OpenAddressModal()
        {
            CustomerForm.AddAddressButton.Click();
            Thread.Sleep(500);
        }

        public static void AddCustomer()
        {
            CustomerForm.AddCustomerButton.Click();
            Thread.Sleep(2000);
        }

        public static void PopulateCompanyDetails(string name, string nip, string regon, string email, string phone)
        {
            CustomerForm.CompanyName.SendKeys(name);
            CustomerForm.CompanyEmail.SendKeys(email);
            CustomerForm.CompanyPhone.SendKeys(phone);
            CustomerForm.CompanyNip.SendKeys(nip);
            CustomerForm.CompanyRegon.SendKeys(regon);
        }

        public static void PopulatePersonDetails(string name, string lastName, string email, string phone)
        {
            CustomerForm.CustomerName.SendKeys(name);
            CustomerForm.CustomerLastName.SendKeys(lastName);
            CustomerForm.CustomerPhone.SendKeys(phone);
            CustomerForm.CustomerEmail.SendKeys(email);
        }
    }
}

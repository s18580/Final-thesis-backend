using Application.Tests.Mappings.AddressModal;
using Application.Tests.Mappings.CustomerForm;
using Application.Tests.Mappings.LoginPage;
using Application.Tests.Mappings.NavBar;
using Application.Tests.Mappings.RepresentativeModal;
using Application.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Tests.Customer
{
    [TestClass]
    public class CompanyCustomerTests : TestMasterPage
    {
        [TestMethod, TestCategory("CompanyCustomer")]
        public void AddCompanyCustomer()
        {
            var userData = UsersTestData.GetAdminAccount();
            var customer = CustomerTestData.GetCompanyCustomer();
            var representative = RepresentativeTestData.GetRepresentative();
            var address = AddressTestData.GetAddress();

            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            NavBarActions.InitPage(_driver);
            NavBarActions.GoToAddCustomerPage();

            CustomerActions.InitPage(_driver);
            CustomerActions.SetCustomerTypeOnCompany();
            CustomerActions.PopulateCompanyDetails(customer.CompanyName, customer.NIP, customer.Regon, customer.CompanyEmail, customer.CompanyPhone);

            CustomerActions.OpenRepresentativeModal();
            RepresentativeActions.InitPage(_driver);
            RepresentativeActions.PopulateRepresentativeDetails(representative.Name, representative.LastName, representative.Phone, representative.Email);
            RepresentativeActions.AddRepresentative();

            CustomerActions.OpenAddressModal();
            AddressActions.InitPage(_driver);
            AddressActions.PopulateAddressDetails(address.Name, address.Country, address.City, address.StreetName, address.StreetNumber, address.ApartmentNumber, address.PostCode);
            AddressActions.AddAddress();

            CustomerActions.AddCustomer();

            Assert.IsTrue(NavBarActions.CheckToastMessage("Klient został dodany."));
        }
    }
}

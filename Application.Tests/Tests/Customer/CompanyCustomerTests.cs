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
        public void AddCompanyCustomerWithAllData()
        {
            var userData = UsersTestData.GetAdminAccount();

            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            NavBarActions.InitPage(_driver);
            NavBarActions.GoToAddCustomerPage();

            CustomerActions.InitPage(_driver);
            CustomerActions.SetCustomerTypeOnCompany();
            CustomerActions.PopulateCompanyDetails("TestName", "2343234567", "2342233223", "TestEmail", "456456456");

            CustomerActions.OpenRepresentativeModal();
            RepresentativeActions.InitPage(_driver);
            RepresentativeActions.PopulateRepresentativeDetails("RepName", "RepLastName", "456456456", "RepEmail");
            RepresentativeActions.AddRepresentative();

            CustomerActions.OpenAddressModal();
            AddressActions.InitPage(_driver);
            AddressActions.PopulateAddressDetails("TestAddress", "Polska", "Milanówek", "Polna", "11", "2A", "05-822");
            AddressActions.AddAddress();

            CustomerActions.AddCustomer();
            Assert.IsTrue(NavBarActions.CheckToastMessage("Klient został dodany."));
        }
    }
}

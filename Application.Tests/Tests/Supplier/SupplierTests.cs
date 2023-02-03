using Application.Tests.Mappings.AddressModal;
using Application.Tests.Mappings.SupplierForm;
using Application.Tests.Mappings.LoginPage;
using Application.Tests.Mappings.NavBar;
using Application.Tests.Mappings.RepresentativeModal;
using Application.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Tests.Supplier
{
    [TestClass]
    public class SupplierTests : TestMasterPage
    {
        [TestMethod, TestCategory("Supplier")]
        public void AddSupplier()
        {
            var userData = UsersTestData.GetAdminAccount();
            var supplier = SupplierTestData.GetSupplier();
            var representative = RepresentativeTestData.GetRepresentative();
            var address = AddressTestData.GetAddress();

            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            NavBarActions.InitPage(_driver);
            NavBarActions.GoToAddSupplierPage();

            SupplierActions.InitPage(_driver);
            SupplierActions.PopulateSupplierDetails(supplier.Name, supplier.Description, supplier.Email, supplier.Phone);

            SupplierActions.OpenRepresentativeModal();
            RepresentativeActions.InitPage(_driver);
            RepresentativeActions.PopulateRepresentativeDetails(representative.Name, representative.LastName, representative.Phone, representative.Email);
            RepresentativeActions.AddRepresentative();

            SupplierActions.OpenAddressModal();
            AddressActions.InitPage(_driver);
            AddressActions.PopulateAddressDetails(address.Name, address.Country, address.City, address.StreetName, address.StreetNumber, address.ApartmentNumber, address.PostCode);
            AddressActions.AddAddress();

            SupplierActions.AddSupplier();
            Assert.IsTrue(NavBarActions.CheckToastMessage("Dostawca został dodany."));
        }
    }
}

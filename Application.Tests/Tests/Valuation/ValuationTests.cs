using Application.Tests.Mappings.ColorModal;
using Application.Tests.Mappings.LoginPage;
using Application.Tests.Mappings.NavBar;
using Application.Tests.Mappings.PaperModal;
using Application.Tests.Mappings.ServiceModal;
using Application.Tests.Mappings.ValuationDetails;
using Application.Tests.Mappings.ValuationForm;
using Application.Tests.Mappings.ValuationSearch;
using Application.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Tests.Valuation
{
    [TestClass]
    public class ValuationTests : TestMasterPage
    {
        [TestMethod, TestCategory("Valuation")]
        public void CopyValuation()
        {
            var userData = UsersTestData.GetAdminAccount();

            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            NavBarActions.InitPage(_driver);
            NavBarActions.GoToSearchValuationPage();

            ValuationSearchActions.InitPage(_driver);
            ValuationSearchActions.SearchForResults();
            ValuationSearchActions.SelectValuation();

            ValuationDetailsActions.InitPage(_driver);
            ValuationDetailsActions.CopyValuation();

            NavBarActions.GoToAddValuationPage();
            ValuationFormActions.InitPage(_driver);

            Assert.IsTrue(ValuationFormActions.CheckCopyValuation(false));
        }

        [TestMethod, TestCategory("Valuation")]
        public void AddBlankValuationWithoutCover()
        {
            var userData = UsersTestData.GetAdminAccount();
            var valuation = ValuationTestData.GetValuationWithoutCover();
            var color = valuation.InsideColors[0];
            var paper = valuation.InsidePapers[0];
            var service = valuation.InsideServices[0];


            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            NavBarActions.InitPage(_driver);
            NavBarActions.GoToAddValuationPage();

            ValuationFormActions.InitPage(_driver);
            ValuationFormActions.PopulateValuationForm(false, false, valuation);

            ValuationFormActions.OpenInsideColorModal();
            ColorModalActions.InitPage(_driver);
            ColorModalActions.PopulateColorModal(color.Name);
            ColorModalActions.AddColor();

            ValuationFormActions.OpenInsidePaperModal();
            PaperModalActions.InitPage(_driver);
            PaperModalActions.PopulatePaperModal(paper.Name, paper.Type, paper.Format, paper.Opacity, paper.Quantity, paper.PerKilo, paper.FiberDirection);
            PaperModalActions.AddPaper();

            ValuationFormActions.OpenInsideServiceModal();
            ServiceModalActions.InitPage(_driver);
            ServiceModalActions.PopulateServiceModal(service.Name, service.Price);
            ServiceModalActions.AddService();

            ValuationFormActions.CalculatePrice();
            ValuationFormActions.AddValuation();
        }
    }
}

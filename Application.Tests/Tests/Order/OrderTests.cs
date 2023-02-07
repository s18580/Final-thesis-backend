using Application.Tests.Mappings.ColorModal;
using Application.Tests.Mappings.DeliveryAddressesModal;
using Application.Tests.Mappings.LoginPage;
using Application.Tests.Mappings.NavBar;
using Application.Tests.Mappings.OrderForm;
using Application.Tests.Mappings.OrderItemModal;
using Application.Tests.Mappings.PaperModal;
using Application.Tests.Mappings.ServiceModal;
using Application.Tests.Mappings.WorkerModal;
using Application.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Tests.Order
{
    [TestClass]
    public class OrderTests : TestMasterPage
    {
        [TestMethod, TestCategory("Order")]
        public void AddOrderWithBusimessCards()
        {
            var userData = UsersTestData.GetAdminAccount();
            var assignment = AssignmentTestData.GetAssignment();
            var deliveryAddress = DeliveryAddressesTestData.GetDeliveryAddress();
            var order = OrderTestData.GetOrder();
            var orderItem = OrderItemTestData.GetOrderItemWithoutCover();

            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            NavBarActions.InitPage(_driver);
            NavBarActions.GoToAddOrderPage();

            OrderFormActions.InitPage(_driver);
            OrderFormActions.PopulateOrderDetails(order.IsAuction, order.Name, order.Note, order.ExpectedDeliveryDate, order.OfferValidityDate, order.Customer, order.Representative, order.OrderStatus);

            OrderFormActions.OpenWorkerModal();
            WorkerModalActions.InitPage(_driver);
            WorkerModalActions.PopulateAssignmentDetails(assignment.IsLeader, assignment.Name);
            WorkerModalActions.AddAssignment();

            OrderFormActions.OpenAddressModal();
            DeliveryAddressesModalActions.InitPage(_driver);
            DeliveryAddressesModalActions.PopulateDeliveryAddressesModal(deliveryAddress.Name);
            DeliveryAddressesModalActions.AddDeliveryAddress();

            OrderFormActions.OpenOrderItemModal();
            OrderItemModalActions.InitPage(_driver);
            OrderItemModalActions.PopulateOrderDetails(orderItem.IsWithCover, orderItem.OrderItemName, orderItem.Note, orderItem.WantedFinishDate, orderItem.InsideFormat, orderItem.Circulation, orderItem.OrderItemType, orderItem.DeliveryType, orderItem.CoverFormat, orderItem.BindingType, orderItem.Capacity);
            OrderItemModalActions.AddOrderItem();

            var color = orderItem.InsideColors[0];
            OrderItemModalActions.OpenInsideColor();
            ColorModalActions.InitPage(_driver);
            ColorModalActions.PopulateColorModal(color.Name);
            ColorModalActions.AddColor();

            var paper = orderItem.InsidePapers[0];
            OrderItemModalActions.OpenInsidePaper();
            PaperModalActions.InitPage(_driver);
            PaperModalActions.PopulatePaperModal(paper.Name, paper.Type, paper.Format, paper.Opacity, paper.Quantity, paper.PerKilo, paper.FiberDirection);
            PaperModalActions.AddPaper();

            var service = orderItem.InsideServices[0];
            OrderItemModalActions.OpenInsideService();
            ServiceModalActions.InitPage(_driver);
            ServiceModalActions.PopulateServiceModal(service.Name, service.Price);
            ServiceModalActions.AddService();

            OrderFormActions.AddOrder();

            Assert.IsTrue(NavBarActions.CheckToastMessage("Zamówienie zostało dodane."));
        }

        [TestMethod, TestCategory("Order")]
        public void AddOrderWithBooklet()
        {
            var userData = UsersTestData.GetAdminAccount();
            var assignment = AssignmentTestData.GetAssignment();
            var deliveryAddress = DeliveryAddressesTestData.GetDeliveryAddress();
            var order = OrderTestData.GetOrder();
            var orderItem = OrderItemTestData.GetOrderItemWithCover();

            LoginActions.InitPage(_driver);
            LoginActions.Login(userData.Email, userData.Password);

            NavBarActions.InitPage(_driver);
            NavBarActions.GoToAddOrderPage();

            OrderFormActions.InitPage(_driver);
            OrderFormActions.PopulateOrderDetails(order.IsAuction, order.Name, order.Note, order.ExpectedDeliveryDate, order.OfferValidityDate, order.Customer, order.Representative, order.OrderStatus);

            OrderFormActions.OpenWorkerModal();
            WorkerModalActions.InitPage(_driver);
            WorkerModalActions.PopulateAssignmentDetails(assignment.IsLeader, assignment.Name);
            WorkerModalActions.AddAssignment();

            OrderFormActions.OpenAddressModal();
            DeliveryAddressesModalActions.InitPage(_driver);
            DeliveryAddressesModalActions.PopulateDeliveryAddressesModal(deliveryAddress.Name);
            DeliveryAddressesModalActions.AddDeliveryAddress();

            OrderFormActions.OpenOrderItemModal();
            OrderItemModalActions.InitPage(_driver);
            OrderItemModalActions.PopulateOrderDetails(orderItem.IsWithCover, orderItem.OrderItemName, orderItem.Note, orderItem.WantedFinishDate, orderItem.InsideFormat, orderItem.Circulation, orderItem.OrderItemType, orderItem.DeliveryType, orderItem.CoverFormat, orderItem.BindingType, orderItem.Capacity);
            OrderItemModalActions.AddOrderItem();

            var color = orderItem.InsideColors[0];
            OrderItemModalActions.OpenInsideColor();
            ColorModalActions.InitPage(_driver);
            ColorModalActions.PopulateColorModal(color.Name);
            ColorModalActions.AddColor();

            var paper = orderItem.InsidePapers[0];
            OrderItemModalActions.OpenInsidePaper();
            PaperModalActions.InitPage(_driver);
            PaperModalActions.PopulatePaperModal(paper.Name, paper.Type, paper.Format, paper.Opacity, paper.Quantity, paper.PerKilo, paper.FiberDirection);
            PaperModalActions.AddPaper();

            var service = orderItem.InsideServices[0];
            OrderItemModalActions.OpenInsideService();
            ServiceModalActions.InitPage(_driver);
            ServiceModalActions.PopulateServiceModal(service.Name, service.Price);
            ServiceModalActions.AddService();

            var colorCover = orderItem.CoverColors[0];
            OrderItemModalActions.OpenCoverColor();
            ColorModalActions.InitPage(_driver);
            ColorModalActions.PopulateColorModal(colorCover.Name);
            ColorModalActions.AddColor();

            var paperCover = orderItem.CoverPapers[0];
            OrderItemModalActions.OpenCoverPaper();
            PaperModalActions.InitPage(_driver);
            PaperModalActions.PopulatePaperModal(paperCover.Name, paperCover.Type, paperCover.Format, paperCover.Opacity, paperCover.Quantity, paperCover.PerKilo, paperCover.FiberDirection);
            PaperModalActions.AddPaper();

            var serviceCover = orderItem.CoverServices[0];
            OrderItemModalActions.OpenCoverService();
            ServiceModalActions.InitPage(_driver);
            ServiceModalActions.PopulateServiceModal(serviceCover.Name, serviceCover.Price);
            ServiceModalActions.AddService();

            OrderFormActions.AddOrder();

            Assert.IsTrue(NavBarActions.CheckToastMessage("Zamówienie zostało dodane."));
        }
    }
}
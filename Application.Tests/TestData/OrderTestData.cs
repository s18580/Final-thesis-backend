using System;

namespace Application.Tests.TestData
{
    public class OrderTestData
    {
        public static OrderData GetOrder()
        {
            return new OrderData("Testowe zamówienie", false, DateTime.Now, DateTime.Now, "Testowa notatka", "MEGLER", "Hester Gibbon", "Przygotowanie wyceny");
        }
    }

    public struct OrderData
    {
        public string Name { get; set; }
        public bool IsAuction { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public DateTime OfferValidityDate { get; set; }
        public string Note { get; set; }
        public string Customer { get; set; }
        public string Representative { get; set; }
        public string OrderStatus { get; set; }

        public OrderData(string name, bool isAuction, DateTime expectedDeliveryDate, DateTime offerValidityDate, string note, string customer, string representative, string orderStatus)
        {
            Name = name;
            IsAuction = isAuction;
            ExpectedDeliveryDate = expectedDeliveryDate;
            OfferValidityDate = offerValidityDate;
            Note = note;
            Customer = customer;
            Representative = representative;
            OrderStatus = orderStatus;
        }
    }
}

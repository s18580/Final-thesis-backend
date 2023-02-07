using System;

namespace Application.Tests.TestData
{
    public class SupplyTestData
    {
        public static SupplyData GetSupply()
        {
            return new SupplyData(200, 1, "Farba P234", DateTime.Now.AddDays(20), "Farba", "ChemTech", "Harmonia Hayth");
        }
    }

    public struct SupplyData
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTime SupplyDate { get; set; }
        public string SupplyItemType { get; set; }
        public string Supplier { get; set; }
        public string Representative { get; set; }

        public SupplyData(double price, int quantity, string description, DateTime supplyDate, string supplyItemType, string supplier, string representative)
        {
            Price = price;
            Quantity = quantity;
            Description = description;
            SupplyDate = supplyDate;
            SupplyItemType = supplyItemType;
            Supplier = supplier;
            Representative = representative;
        }
    }
}

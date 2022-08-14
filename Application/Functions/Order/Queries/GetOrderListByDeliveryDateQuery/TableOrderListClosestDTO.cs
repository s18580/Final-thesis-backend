namespace Application.Functions.Order.Queries.GetOrderListByDeliveryDateQuery
{
    public class TableOrderListClosestDTO
    {
        public int IdOrder { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public string ExpectedDeliveryDate { get; set; }
        public bool IsAuction { get; set; }
        public string StatusName { get; set; }
        public string StatusColor { get; set; }
        public List<string> OrderItemsNames { get; set; }
    }
}

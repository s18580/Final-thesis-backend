namespace Application.Functions.Order.Queries.GetOrderListByWorkerQuery
{
    public class TableOrderListDTO
    {
        public int IdOrder { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public bool IsAuction { get; set; }
        public string StatusName { get; set; }
        public List<string> OrderItemsNames { get; set; }
    }
}

namespace Application.Functions.OrderItem
{
    public class GetServiceDTO
    {
        public int IdService { get; set; }
        public double Price { get; set; }
        public bool IsForCover { get; set; }
        public int? IdOrderItem { get; set; }
        public int? IdValuation { get; set; }
        public int IdServiceName { get; set; }
        public string Name { get; set; }

        public Domain.Models.DictionaryModels.ServiceName ServiceName { get; set; }
    }
}

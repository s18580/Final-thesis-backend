namespace Application.Functions.OrderItem
{
    public class ServiceUpdateDTO
    {
        public int IdService { get; set; }
        public double Price { get; set; }
        public bool IsForCover { get; set; }
        public int IdServiceName { get; set; }
    }
}

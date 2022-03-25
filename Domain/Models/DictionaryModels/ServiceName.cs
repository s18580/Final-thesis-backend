namespace Domain.Models.DictionaryModels
{
    public class ServiceName
    {
        public int IdServiceName { get; set; }
        public string Name { get; set; }
        public double? DefaultPrice { get; set; }
        public int? IdMinimumRate { get; set; }

        public MinimumRate MinimumRate { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}

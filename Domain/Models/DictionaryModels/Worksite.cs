namespace Domain.Models.DictionaryModels
{
    public class Worksite
    {
        public int IdWorksite { get; set; }
        public string Name { get; set; }

        public ICollection<Worker> Workers { get; set; }
    }
}

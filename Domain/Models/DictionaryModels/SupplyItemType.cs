namespace Domain.Models.DictionaryModels
{
    public class SupplyItemType
    {
        public int IdSupplyItemType { get; set; }
        public string Name { get; set; }

        public ICollection<Supply> Supplies { get; set; }
    }
}

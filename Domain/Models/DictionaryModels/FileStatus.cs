namespace Domain.Models.DictionaryModels
{
    public class FileStatus
    {
        public int IdFileStatus { get; set; }
        public string Name { get; set; }

        public ICollection<File> Files { get; set; }
    }
}

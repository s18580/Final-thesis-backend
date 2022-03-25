namespace Domain.Models.DictionaryModels
{
    public class FileType
    {
        public int IdFileType { get; set; }
        public string Name { get; set; }

        public ICollection<File> Files { get; set; }
    }
}

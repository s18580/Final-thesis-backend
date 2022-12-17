using Domain.Models.DictionaryModels;

namespace Domain.Models
{
    public class File
    {
        public string FileKey { get; set; }
        public int IdFileType { get; set; }
        public int? IdFileStatus { get; set; }
        public int? IdValuation { get; set; }
        public int? IdOrder { get; set; }

        public FileType FileType { get; set; }
        public FileStatus? FileStatus { get; set; }
        public Order? Order { get; set; }
        public Valuation? Valuation { get; set; }
    }
}

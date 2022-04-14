using MediatR;

namespace Application.Functions.FileType.Queries.GetFileTypeQuery
{
    public class GetFileTypeQuery : IRequest<Domain.Models.DictionaryModels.FileType>
    {
        public int IdFileType { get; set; }
    }
}

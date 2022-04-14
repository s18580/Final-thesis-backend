using MediatR;

namespace Application.Functions.FileType.Queries.GetFileTypeListQuery
{
    public class GetFileTypeListQuery : IRequest<List<Domain.Models.DictionaryModels.FileType>>
    {
    }
}

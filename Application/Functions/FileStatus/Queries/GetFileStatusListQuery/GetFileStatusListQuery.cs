using MediatR;

namespace Application.Functions.FileStatus.Queries.GetFileStatusListQuery
{
    public class GetFileStatusListQuery : IRequest<List<Domain.Models.DictionaryModels.FileStatus>>
    {
    }
}

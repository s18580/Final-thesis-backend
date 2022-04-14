using MediatR;

namespace Application.Functions.FileStatus.Queries.GetFileStatusQuery
{
    public class GetFileStatusQuery : IRequest<Domain.Models.DictionaryModels.FileStatus>
    {
        public int IdFileStatus { get; set; }
    }
}

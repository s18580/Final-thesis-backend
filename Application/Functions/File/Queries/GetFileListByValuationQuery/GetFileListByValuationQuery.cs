using MediatR;

namespace Application.Functions.File.Queries.GetFileListByValuationQuery
{
    public class GetFileListByValuationQuery : IRequest<GetFileListByValuationResponse>
    {
        public int IdValuation { get; set; }
    }
}

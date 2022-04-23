using MediatR;

namespace Application.Functions.File.Queries.GetFileListByOrderQuery
{
    public class GetFileListByOrderQuery : IRequest<GetFileListByOrderResponse>
    {
        public int IdOrder { get; set; }
    }
}

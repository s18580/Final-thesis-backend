using MediatR;

namespace Application.Functions.File.Queries.GetFileListByOrderItemQuery
{
    public class GetFileListByOrderItemQuery : IRequest<GetFileListByOrderItemResponse>
    {
        public int IdOrderItem { get; set; }
    }
}

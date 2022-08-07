using MediatR;

namespace Application.Functions.Order.Queries.GetOrderListByWorkerQuery
{
    public class GetOrderListByWorkerQuery : IRequest<GetOrderListByWorkerResponse>
    {
        public int IdWorker { get; set; }
    }
}

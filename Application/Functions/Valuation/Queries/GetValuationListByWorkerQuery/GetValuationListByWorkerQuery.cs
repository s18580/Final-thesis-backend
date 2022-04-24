using MediatR;

namespace Application.Functions.Valuation.Queries.GetValuationListByWorkerQuery
{
    public class GetValuationListByWorkerQuery : IRequest<GetValuationListByWorkerResponse>
    {
        public int IdWorker { get; set; }
    }
}

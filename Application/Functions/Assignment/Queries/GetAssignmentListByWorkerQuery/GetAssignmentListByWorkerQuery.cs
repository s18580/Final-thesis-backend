using MediatR;

namespace Application.Functions.Assignment.Queries.GetAssignmentListByWorkerQuery
{
    public class GetAssignmentListByWorkerQuery : IRequest<GetAssignmentListByWorkerResponse>
    {
        public int IdWorker { get; set; }
    }
}

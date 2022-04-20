using MediatR;

namespace Application.Functions.Assignment.Queries.GetAssignmentQuery
{
    public class GetAssignmentQuery : IRequest<Domain.Models.Assignment>
    {
        public int IdWorker { get; set; }
        public int IdOrder { get; set; }
    }
}

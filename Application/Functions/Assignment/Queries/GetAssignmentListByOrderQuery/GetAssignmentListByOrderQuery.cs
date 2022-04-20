using MediatR;

namespace Application.Functions.Assignment.Queries.GetAssignmentListByOrderQuery
{
    public class GetAssignmentListByOrderQuery : IRequest<GetAssignmentListByOrderResponse>
    {
        public int IdOrder { get; set; }
    }
}

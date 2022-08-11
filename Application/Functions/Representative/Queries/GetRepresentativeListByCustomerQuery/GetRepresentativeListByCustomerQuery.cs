using MediatR;

namespace Application.Functions.Representative.Queries.GetRepresentativeListByCustomerQuery
{
    public class GetRepresentativeListByCustomerQuery : IRequest<GetRepresentativeListByCustomerResponse>
    {
        public int CustomerId { get; set; }
    }
}

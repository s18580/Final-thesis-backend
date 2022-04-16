using MediatR;

namespace Application.Functions.Representative.Queries.GetRepresentativeListQuery
{
    public class GetRepresentativeListQuery : IRequest<List<Domain.Models.Representative>>
    {
    }
}

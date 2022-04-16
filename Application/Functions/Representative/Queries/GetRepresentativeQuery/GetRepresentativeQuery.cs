using MediatR;

namespace Application.Functions.Representative.Queries.GetRepresentativeQuery
{
    public class GetRepresentativeQuery : IRequest<Domain.Models.Representative>
    {
        public int IdRepresentative { get; set; }
    }
}

using MediatR;

namespace Application.Functions.Valuation.Commands.DeleteValuationCommand
{
    public class DeleteValuationCommand : IRequest<DeleteValuationResponse>
    {
        public int IdValuation { get; set; }
    }
}

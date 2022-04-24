using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Valuation.Commands.DeleteValuationCommand
{
    public class DeleteValuationCommandHandler : IRequestHandler<DeleteValuationCommand, DeleteValuationResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteValuationCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteValuationResponse> Handle(DeleteValuationCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteValuationValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteValuationResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var valuationDelete = await _context.Valuations
                                                .Where(p => p.IdValuation == request.IdValuation)
                                                .SingleAsync();

            _context.Valuations.Remove(valuationDelete);
            await _context.SaveChangesAsync();

            return new DeleteValuationResponse();
        }
    }
}

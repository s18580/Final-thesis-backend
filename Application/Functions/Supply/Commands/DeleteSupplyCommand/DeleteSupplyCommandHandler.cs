using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Supply.Commands.DeleteSupplyCommand
{
    public class DeleteSupplyCommandHandler : IRequestHandler<DeleteSupplyCommand, DeleteSupplyResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteSupplyCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteSupplyResponse> Handle(DeleteSupplyCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteSupplyValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteSupplyResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var supplyDelete = await _context.Supplies
                                             .Where(p => p.IdSupply == request.IdSupply)
                                             .SingleAsync();

            _context.Supplies.Remove(supplyDelete);
            await _context.SaveChangesAsync();

            return new DeleteSupplyResponse();
        }
    }
}

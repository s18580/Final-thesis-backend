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

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                /*
                var deliveryAddresses = await _context.DeliveriesAddresses
                                                  .Where(p => p.IdSupply == request.IdSupply)
                                                  .ToListAsync();

                _context.DeliveriesAddresses.RemoveRange(deliveryAddresses);
                await _context.SaveChangesAsync();
                */
                var supplyDelete = await _context.Supplies
                                                 .Include(p => p.DeliveriesAddresses)
                                                 .Where(p => p.IdSupply == request.IdSupply)
                                                 .SingleAsync();

                _context.Supplies.Remove(supplyDelete);
                await _context.SaveChangesAsync();

                dbContextTransaction.Commit();
            }

            return new DeleteSupplyResponse();
        }
    }
}

using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.PriceList.Commands.DeletePriceListCommand
{
    public class DeletePriceListCommandHandler : IRequestHandler<DeletePriceListCommand, DeletePriceListResponse>
    {
        private readonly IApplicationContext _context;

        public DeletePriceListCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeletePriceListResponse> Handle(DeletePriceListCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeletePriceListValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeletePriceListResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var priceListDelete = await _context.PriceLists
                                                .Where(p => p.IdPriceList == request.IdPriceList)
                                                .SingleAsync();

            _context.PriceLists.Remove(priceListDelete);
            await _context.SaveChangesAsync();

            return new DeletePriceListResponse();
        }
    }
}

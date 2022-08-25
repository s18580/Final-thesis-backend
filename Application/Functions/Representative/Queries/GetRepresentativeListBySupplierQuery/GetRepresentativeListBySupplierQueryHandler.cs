using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Queries.GetRepresentativeListBySupplierQuery
{
    public class GetRepresentativeListBySupplierQueryHandler : IRequestHandler<GetRepresentativeListBySupplierQuery, GetRepresentativeListBySupplierResponse>
    {
        private readonly IApplicationContext _context;

        public GetRepresentativeListBySupplierQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetRepresentativeListBySupplierResponse> Handle(GetRepresentativeListBySupplierQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetRepresentativeListBySupplierValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetRepresentativeListBySupplierResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var representatives = await _context.Representatives
                                                .Where(p => p.IdSupplier == request.SupplierId)
                                                .ToListAsync();

            return new GetRepresentativeListBySupplierResponse(representatives);
        }
    }
}

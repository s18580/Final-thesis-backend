using Application.Services;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Application.Functions.Representative.Commands.DisableRepresentativeCommand
{
    public class DisableRepresentativeCommandHandler : IRequestHandler<DisableRepresentativeCommand, DisableRepresentativeResponse>
    {
        private readonly IApplicationContext _context;

        public DisableRepresentativeCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DisableRepresentativeResponse> Handle(DisableRepresentativeCommand request, CancellationToken cancellationToken)
        {
            var validator = new DisableRepresentativeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DisableRepresentativeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var representative = await _context.Representatives.Where(p => p.IdRepresentative == request.Id).SingleAsync();
            representative.IsDisabled = request.IsDisabled;

            await _context.SaveChangesAsync();

            return new DisableRepresentativeResponse();
        }
    }
}

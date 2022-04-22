using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Service.Commands.UpdateServiceCommand
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, UpdateServiceResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateServiceCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateServiceResponse> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateServiceValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateServiceResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedService = await _context.Services
                                                .Where(p => p.IdService == request.IdService)
                                                .SingleAsync();

            if (selectedService.Price != request.Price) { selectedService.Price = request.Price; }
            if (selectedService.IsForCover != request.IsForCover) { selectedService.IsForCover = request.IsForCover; }

            await _context.SaveChangesAsync();

            return new UpdateServiceResponse();
        }
    }
}

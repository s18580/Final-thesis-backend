using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.ServiceName.Commands.UpdateServiceNameCommand
{
    public class UpdateServiceNameCommandHandler : IRequestHandler<UpdateServiceNameCommand, UpdateServiceNameResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateServiceNameCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateServiceNameResponse> Handle(UpdateServiceNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateServiceNameValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateServiceNameResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedServiceName = await _context.ServiceNames
                                                    .Where(p => p.IdServiceName == request.IdServiceName)
                                                    .SingleAsync();

            if (selectedServiceName.Name != request.Name) { selectedServiceName.Name = request.Name; }
            if (selectedServiceName.DefaultPrice != request.DefaultPrice) { selectedServiceName.DefaultPrice = request.DefaultPrice; }
            if (selectedServiceName.MinimumPrice != request.MinimumPrice) { selectedServiceName.MinimumPrice = request.MinimumPrice; }
            if (selectedServiceName.MinimumCirculation != request.MinimumCirculation) { selectedServiceName.MinimumCirculation = request.MinimumCirculation; }

            await _context.SaveChangesAsync();

            return new UpdateServiceNameResponse();
        }
    }
}

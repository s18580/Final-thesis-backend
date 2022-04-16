using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Commands.UpdateRepresentativeCommand
{
    public class UpdateRepresentativeCommandHandler : IRequestHandler<UpdateRepresentativeCommand, UpdateRepresentativeResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateRepresentativeCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateRepresentativeResponse> Handle(UpdateRepresentativeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRepresentativeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateRepresentativeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedRepresentative = await _context.Representatives
                                                 .Where(p => p.IdRepresentative == request.IdRepresentative)
                                                 .SingleAsync();

            if (selectedRepresentative.Name != request.Name) { selectedRepresentative.Name = request.Name; }
            if (selectedRepresentative.LastName != request.LastName) { selectedRepresentative.LastName = request.LastName; }
            if (selectedRepresentative.PhoneNumber != request.PhoneNumber) { selectedRepresentative.PhoneNumber = request.PhoneNumber; }
            if (selectedRepresentative.EmailAddress != request.EmailAddress) { selectedRepresentative.EmailAddress = request.EmailAddress; }
            if (selectedRepresentative.IdOwner != request.IdOwner) { selectedRepresentative.IdOwner = request.IdOwner; }

            await _context.SaveChangesAsync();

            return new UpdateRepresentativeResponse();
        }
    }
}

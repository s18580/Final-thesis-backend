using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Commands.DeleteRepresentativeCommand
{
    public class DeleteRepresentativeCommandHandler : IRequestHandler<DeleteRepresentativeCommand, DeleteRepresentativeResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteRepresentativeCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteRepresentativeResponse> Handle(DeleteRepresentativeCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteRepresentativeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteRepresentativeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var representativeDelete = await _context.Representatives
                                                     .Where(p => p.IdRepresentative == request.IdRepresentative)
                                                     .SingleAsync();

            _context.Representatives.Remove(representativeDelete);
            await _context.SaveChangesAsync();

            return new DeleteRepresentativeResponse();
        }
    }
}

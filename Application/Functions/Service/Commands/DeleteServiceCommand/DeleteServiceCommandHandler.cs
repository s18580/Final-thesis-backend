using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Service.Commands.DeleteServiceCommand
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, DeleteServiceResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteServiceCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteServiceResponse> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteServiceValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteServiceResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var serviceToDelete = await _context.Services
                                                .Where(p => p.IdService == request.IdService)
                                                .SingleAsync();

            _context.Services.Remove(serviceToDelete);
            await _context.SaveChangesAsync();

            return new DeleteServiceResponse();
        }
    }
}

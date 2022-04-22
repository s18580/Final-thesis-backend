using Application.Services;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Application.Functions.ServiceName.Commands.DeleteServiceNameCommand
{
    public class DeleteServiceNameCommandHandler : IRequestHandler<DeleteServiceNameCommand, DeleteServiceNameResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteServiceNameCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteServiceNameResponse> Handle(DeleteServiceNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteServiceNameValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteServiceNameResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var serviceNamesDelete = await _context.ServiceNames
                                                   .Where(p => p.IdServiceName == request.IdServiceName)
                                                   .SingleAsync();

            _context.ServiceNames.Remove(serviceNamesDelete);
            await _context.SaveChangesAsync();

            return new DeleteServiceNameResponse();
        }
    }
}

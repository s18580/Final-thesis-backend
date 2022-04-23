using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Color.Commands.DeleteColorCommand
{
    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, DeleteColorResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteColorCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteColorResponse> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteColorValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteColorResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var colorDelete = await _context.Colors
                                            .Where(p => p.IdColor == request.IdColor)
                                            .SingleAsync();

            _context.Colors.Remove(colorDelete);
            await _context.SaveChangesAsync();

            return new DeleteColorResponse();
        }
    }
}

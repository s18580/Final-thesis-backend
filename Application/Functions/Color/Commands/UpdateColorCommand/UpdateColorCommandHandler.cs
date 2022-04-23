using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Color.Commands.UpdateColorCommand
{
    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, UpdateColorResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateColorCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateColorResponse> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateColorValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateColorResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedColor = await _context.Colors
                                              .Where(p => p.IdColor == request.IdColor)
                                              .SingleAsync();

            if (selectedColor.Name != request.Name) { selectedColor.Name = request.Name; }
            if (selectedColor.IsForCover != request.IsForCover) { selectedColor.IsForCover = request.IsForCover; }

            await _context.SaveChangesAsync();

            return new UpdateColorResponse();
        }
    }
}

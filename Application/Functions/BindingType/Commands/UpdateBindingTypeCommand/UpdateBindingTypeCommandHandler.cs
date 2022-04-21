using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.BindingType.Commands.UpdateBindingTypeCommand
{
    public class UpdateBindingTypeCommandHandler : IRequestHandler<UpdateBindingTypeCommand, UpdateBindingTypeResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateBindingTypeCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateBindingTypeResponse> Handle(UpdateBindingTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBindingTypeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateBindingTypeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedBindingType = await _context.BindingTypes
                                                    .Where(p => p.IdBindingType == request.IdBindingType)
                                                    .SingleAsync();

            if (selectedBindingType.Name != request.Name) { selectedBindingType.Name = request.Name; }

            await _context.SaveChangesAsync();

            return new UpdateBindingTypeResponse();
        }
    }
}

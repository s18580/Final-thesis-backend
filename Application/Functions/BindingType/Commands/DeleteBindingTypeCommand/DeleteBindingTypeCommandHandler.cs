using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.BindingType.Commands.DeleteBindingTypeCommand
{
    public class DeleteBindingTypeCommandHandler : IRequestHandler<DeleteBindingTypeCommand, DeleteBindingTypeResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteBindingTypeCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteBindingTypeResponse> Handle(DeleteBindingTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteBindingTypeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteBindingTypeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var bindingTypeDelete = await _context.BindingTypes
                                                  .Where(p => p.IdBindingType == request.IdBindingType)
                                                  .Include(p => p.Valuations)
                                                  .Include(p => p.OrderItems)
                                                  .SingleAsync();

            _context.BindingTypes.Remove(bindingTypeDelete);
            await _context.SaveChangesAsync();

            return new DeleteBindingTypeResponse();
        }
    }
}

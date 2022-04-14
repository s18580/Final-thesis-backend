using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.FileType.Commands.UpdateFileTypeCommand
{
    public class UpdateFileTypeCommandHandler : IRequestHandler<UpdateFileTypeCommand, UpdateFileTypeResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateFileTypeCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateFileTypeResponse> Handle(UpdateFileTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFileTypeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateFileTypeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedFileType = await _context.FileTypes
                                                 .Where(p => p.IdFileType == request.IdFileType)
                                                 .SingleAsync();

            if (selectedFileType.Name != request.Name) { selectedFileType.Name = request.Name; }

            await _context.SaveChangesAsync();

            return new UpdateFileTypeResponse();
        }
    }
}

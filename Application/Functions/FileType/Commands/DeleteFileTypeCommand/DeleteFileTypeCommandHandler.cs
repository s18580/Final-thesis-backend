using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.FileType.Commands.DeleteFileTypeCommand
{
    public class DeleteFileTypeCommandHandler : IRequestHandler<DeleteFileTypeCommand, DeleteFileTypeResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteFileTypeCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteFileTypeResponse> Handle(DeleteFileTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteFileTypeValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteFileTypeResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var fileTypeDelete = await _context.FileTypes
                                               .Where(p => p.IdFileType == request.IdFileType)
                                               .SingleAsync();

            _context.FileTypes.Remove(fileTypeDelete);
            await _context.SaveChangesAsync();

            return new DeleteFileTypeResponse();
        }
    }
}

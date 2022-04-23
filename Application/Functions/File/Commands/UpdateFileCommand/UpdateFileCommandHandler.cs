using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.File.Commands.UpdateFileCommand
{
    public class UpdateFileCommandHandler : IRequestHandler<UpdateFileCommand, UpdateFileResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateFileCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateFileResponse> Handle(UpdateFileCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFileValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateFileResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedFile = await _context.Files
                                             .Where(p => p.IdFile == request.IdFile)
                                             .SingleAsync();

            if (selectedFile.Name != request.Name) { selectedFile.Name = request.Name; }
            if (selectedFile.IdFileType != request.IdFileType) { selectedFile.IdFileType = request.IdFileType; }
            if (selectedFile.IdFileStatus != request.IdFileStatus) { selectedFile.IdFileStatus = request.IdFileStatus; }

            await _context.SaveChangesAsync();

            return new UpdateFileResponse();
        }
    }
}

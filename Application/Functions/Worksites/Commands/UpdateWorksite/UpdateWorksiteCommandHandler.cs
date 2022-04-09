using Application.Services;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Worksites.Commands.UpdateWorksite
{
    public class UpdateWorksiteCommandHandler : IRequestHandler<UpdateWorksiteCommand, UpdateWorksiteResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateWorksiteCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateWorksiteResponse> Handle(UpdateWorksiteCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateWorksiteValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateWorksiteResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedWorksite = await _context.Worksites.Where(p => p.IdWorksite == request.IdWorksite).SingleAsync();

            if (selectedWorksite.Name != request.Name) { selectedWorksite.Name = request.Name; }
            
            await _context.SaveChangesAsync();

            return new UpdateWorksiteResponse();
        }
    }
}

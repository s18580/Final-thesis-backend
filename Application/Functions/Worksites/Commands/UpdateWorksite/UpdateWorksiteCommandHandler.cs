using Application.Services;
using AutoMapper;
using Domain.Models.DictionaryModels;
using MediatR;

namespace Application.Functions.Worksites.Commands.UpdateWorksite
{
    public class UpdateWorksiteCommandHandler : IRequestHandler<UpdateWorksiteCommand, UpdateWorksiteResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public UpdateWorksiteCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateWorksiteResponse> Handle(UpdateWorksiteCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateWorksiteValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateWorksiteResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var updatedWorksite = _mapper.Map<Worksite>(request);

            _context.Worksites.Update(updatedWorksite);
            await _context.SaveChangesAsync();

            return new UpdateWorksiteResponse();
        }
    }
}

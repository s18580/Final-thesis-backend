using Application.Services;
using AutoMapper;
using Domain.Models.DictionaryModels;
using MediatR;

namespace Application.Functions.Worksites.Commands.CreateWorksite
{
    public class CreateWorksiteCommandHandler : IRequestHandler<CreateWorksiteCommand, CreateWorksiteResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateWorksiteCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateWorksiteResponse> Handle(CreateWorksiteCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateWorksiteValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateWorksiteResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newWorksite = _mapper.Map<Worksite>(request);

            await _context.Worksites.AddAsync(newWorksite);
            await _context.SaveChangesAsync();

            return new CreateWorksiteResponse();
        }
    }
}

using Application.Services;
using AutoMapper;
using Domain.Models.DictionaryModels;
using MediatR;

namespace Application.Functions.Roles.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CreateRoleResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateRoleCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateRoleResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateRoleValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateRoleResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newRole = _mapper.Map<Role>(request);

            await _context.Roles.AddAsync(newRole);
            await _context.SaveChangesAsync();

            return new CreateRoleResponse(newRole.IdRole);
        }
    }
}

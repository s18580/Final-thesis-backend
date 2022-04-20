using Application.Services;
using MediatR;
using AutoMapper;

namespace Application.Functions.Assignment.Commands.CreateAssignmentCommand
{
    public class CreateAssignmentCommandHandler : IRequestHandler<CreateAssignmentCommand, CreateAssignmentResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateAssignmentCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateAssignmentResponse> Handle(CreateAssignmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAssignmentValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateAssignmentResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newAssignment = _mapper.Map<Domain.Models.Assignment>(request);

            await _context.Assignments.AddAsync(newAssignment);
            await _context.SaveChangesAsync();

            return new CreateAssignmentResponse();
        }
    }
}

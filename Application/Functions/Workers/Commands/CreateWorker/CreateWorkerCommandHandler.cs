using Application.Services;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Functions.Workers.Commands.CreateWorker
{
    public class CreateWorkerCommandHandler : IRequestHandler<CreateWorkerCommand, CreateWorkerResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateWorkerCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateWorkerResponse> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateWorkerValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateWorkerResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newWorker = _mapper.Map<Worker>(request);
            newWorker.PassHash = null;
            newWorker.Salt = null;
            newWorker.IsDisabled = false;

            await _context.Workers.AddAsync(newWorker);
            await _context.SaveChangesAsync();

            return new CreateWorkerResponse(newWorker.IdWorker);
        }
    }
}

using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.Customer.Commands.CreatePersonCustomerCommand
{
    public class CreatePersonCustomerCommandHandler : IRequestHandler<CreatePersonCustomerCommand, CreatePersonCustomerResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreatePersonCustomerCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<CreatePersonCustomerResponse> Handle(CreatePersonCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePersonCustomerValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreatePersonCustomerResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newCustomer = _mapper.Map<Domain.Models.Customer>(request);

            await _context.Customers.AddAsync(newCustomer);
            await _context.SaveChangesAsync();

            return new CreatePersonCustomerResponse();
        }
    }
}

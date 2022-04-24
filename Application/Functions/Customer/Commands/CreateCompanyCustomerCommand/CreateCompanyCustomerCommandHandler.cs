using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.Customer.Commands.CreateCompanyCustomerCommand
{
    public class CreateCompanyCustomerCommandHandler : IRequestHandler<CreateCompanyCustomerCommand, CreateCompanyCustomerResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateCompanyCustomerCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateCompanyCustomerResponse> Handle(CreateCompanyCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCompanyCustomerValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateCompanyCustomerResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newCustomer = _mapper.Map<Domain.Models.Customer>(request);

            await _context.Customers.AddAsync(newCustomer);
            await _context.SaveChangesAsync();

            return new CreateCompanyCustomerResponse(newCustomer.IdCustomer);
        }
    }
}

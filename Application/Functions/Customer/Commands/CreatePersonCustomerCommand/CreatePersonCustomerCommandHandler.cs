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

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                var newPersonDto = new PersonDTO
                {
                    CompanyName = request.Name + " " + request.LastName,
                    NIP = "",
                    Regon = "",
                    CompanyPhoneNumber = request.CompanyPhoneNumber,
                    CompanyEmailAddress = request.CompanyEmailAddress,
                    IdWorker = request.IdWorker
                };

                var newCustomer = _mapper.Map<Domain.Models.Customer>(newPersonDto);

                await _context.Customers.AddAsync(newCustomer);
                await _context.SaveChangesAsync();

                var newRepresentative = new Domain.Models.Representative
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    PhoneNumber = request.CompanyPhoneNumber,
                    EmailAddress = request.CompanyEmailAddress,
                    IdSupplier = null,
                    IdCustomer = newCustomer.IdCustomer
                };

                await _context.Representatives.AddAsync(newRepresentative);
                await _context.SaveChangesAsync();

                dbContextTransaction.Commit();
            }

            return new CreatePersonCustomerResponse();
        }
    }
}

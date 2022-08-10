using Application.Functions.DTOs.DTOsValidators;
using Application.Services;
using MediatR;

namespace Application.Functions.Customer.Commands.CreatePersonCustomerWithDataCommand
{
    public class CreatePersonCustomerWithDataCommandHandler : IRequestHandler<CreatePersonCustomerWithDataCommand, CreatePersonCustomerWithDataResponse>
    {
        private readonly IApplicationContext _context;

        public CreatePersonCustomerWithDataCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<CreatePersonCustomerWithDataResponse> Handle(CreatePersonCustomerWithDataCommand request, CancellationToken cancellationToken)
        {
            // create validators
            var customerValidator = new CreatePersonCustomerWithDataValidator(_context);
            var addressValidator = new AddressDTOValidator();
            var representativeValidator = new RepresentativeDTOValidator();

            // validate data
            var customerValidatorResult = await customerValidator.ValidateAsync(request);
            if (!customerValidatorResult.IsValid) return new CreatePersonCustomerWithDataResponse(customerValidatorResult, Responses.ResponseStatus.ValidationError);

            foreach (var address in request.Addresses)
            {
                var addressValidatorResult = await addressValidator.ValidateAsync(address);
                if (!addressValidatorResult.IsValid) return new CreatePersonCustomerWithDataResponse(addressValidatorResult, Responses.ResponseStatus.ValidationError);
            }

            foreach (var representative in request.Representatives)
            {
                var representativeValidatorResult = await representativeValidator.ValidateAsync(representative);
                if (!representativeValidatorResult.IsValid) return new CreatePersonCustomerWithDataResponse(representativeValidatorResult, Responses.ResponseStatus.ValidationError);
            }

            // create objects in transaction
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                var newCustomer = new Domain.Models.Customer
                {
                    CompanyName = request.Name + " " + request.LastName,
                    NIP = "",
                    Regon = "",
                    CompanyPhoneNumber = request.CompanyPhoneNumber,
                    CompanyEmailAddress = request.CompanyEmailAddress,
                    IdWorker = request.IdWorker,
                };

                await _context.Customers.AddAsync(newCustomer);
                await _context.SaveChangesAsync();

                //add customer as representative ?

                foreach (var address in request.Addresses)
                {
                    var newAddress = new Domain.Models.Address
                    {
                        Name = address.Name,
                        City = address.City,
                        Country = address.Country,
                        PostCode = address.PostCode,
                        StreetName = address.StreetName,
                        StreetNumber = address.StreetNumber,
                        ApartmentNumber = address.ApartmentNumber,
                        IdSupplier = null,
                        IdCustomer = newCustomer.IdCustomer,
                    };

                    await _context.Addresses.AddAsync(newAddress);
                    await _context.SaveChangesAsync();
                }

                foreach (var representative in request.Representatives)
                {
                    var newRepresentative = new Domain.Models.Representative
                    {
                        Name = representative.Name,
                        LastName = representative.LastName,
                        PhoneNumber = representative.PhoneNumber,
                        EmailAddress = representative.EmailAddress,
                        IdSupplier = null,
                        IdCustomer = newCustomer.IdCustomer,
                    };

                    await _context.Representatives.AddAsync(newRepresentative);
                    await _context.SaveChangesAsync();
                }

                dbContextTransaction.Commit();
            }

            return new CreatePersonCustomerWithDataResponse();
        }
    }
}

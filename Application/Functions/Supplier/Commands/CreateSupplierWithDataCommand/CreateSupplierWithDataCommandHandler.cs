using Application.Functions.DTOs.DTOsValidators;
using Application.Services;
using MediatR;

namespace Application.Functions.Supplier.Commands.CreateSupplierWithDataCommand
{
    public class CreateSupplierWithDataCommandHandler : IRequestHandler<CreateSupplierWithDataCommand, CreateSupplierWithDataResponse>
    {
        private readonly IApplicationContext _context;

        public CreateSupplierWithDataCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<CreateSupplierWithDataResponse> Handle(CreateSupplierWithDataCommand request, CancellationToken cancellationToken)
        {
            // create validators
            var supplierValidator = new CreateSupplierWithDataValidator();
            var addressValidator = new AddressDTOValidator();
            var representativeValidator = new RepresentativeDTOValidator();

            // validate data
            var supplierValidatorResult = await supplierValidator.ValidateAsync(request);
            if (!supplierValidatorResult.IsValid) return new CreateSupplierWithDataResponse(supplierValidatorResult, Responses.ResponseStatus.ValidationError);

            foreach (var address in request.Addresses)
            {
                var addressValidatorResult = await addressValidator.ValidateAsync(address);
                if (!addressValidatorResult.IsValid) return new CreateSupplierWithDataResponse(addressValidatorResult, Responses.ResponseStatus.ValidationError);
            }

            foreach (var representative in request.Representatives)
            {
                var representativeValidatorResult = await representativeValidator.ValidateAsync(representative);
                if (!representativeValidatorResult.IsValid) return new CreateSupplierWithDataResponse(representativeValidatorResult, Responses.ResponseStatus.ValidationError);
            }

            // create objects in transaction
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                var newSupplier = new Domain.Models.Supplier
                {
                    Name = request.Name,
                    Description = request.Description,
                    PhoneNumber = request.PhoneNumber,
                    EmailAddress = request.EmailAddress,
                };

                await _context.Suppliers.AddAsync(newSupplier);
                await _context.SaveChangesAsync();

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
                        IdSupplier = newSupplier.IdSupplier,
                        IsDisabled = false,
                        IdCustomer = null,
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
                        IsDisabled = false,
                        IdSupplier = newSupplier.IdSupplier,
                        IdCustomer = null,
                    };

                    await _context.Representatives.AddAsync(newRepresentative);
                    await _context.SaveChangesAsync();
                }

                dbContextTransaction.Commit();
            }

            return new CreateSupplierWithDataResponse();
        }
    }
}

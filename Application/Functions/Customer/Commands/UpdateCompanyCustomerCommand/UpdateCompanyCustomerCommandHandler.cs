using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Customer.Commands.UpdateCompanyCustomerCommand
{
    public class UpdateCompanyCustomerCommandHandler : IRequestHandler<UpdateCompanyCustomerCommand, UpdateCompanyCustomerResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateCompanyCustomerCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateCompanyCustomerResponse> Handle(UpdateCompanyCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCompanyCustomerValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateCompanyCustomerResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedCustomer = await _context.Customers
                                                   .Where(p => p.IdCustomer == request.IdCustomer)
                                                   .SingleAsync();

            if (selectedCustomer.CompanyName != request.CompanyName) { selectedCustomer.CompanyName = request.CompanyName; }
            if (selectedCustomer.NIP != request.NIP) { selectedCustomer.NIP = request.NIP; }
            if (selectedCustomer.Regon != request.Regon) { selectedCustomer.Regon = request.Regon; }
            if (selectedCustomer.CompanyPhoneNumber != request.CompanyPhoneNumber) { selectedCustomer.CompanyPhoneNumber = request.CompanyPhoneNumber; }
            if (selectedCustomer.CompanyEmailAddress != request.CompanyEmailAddress) { selectedCustomer.CompanyEmailAddress = request.CompanyEmailAddress; }
            if (selectedCustomer.IdWorker != request.IdWorker) { selectedCustomer.IdWorker = request.IdWorker; }

            await _context.SaveChangesAsync();

            return new UpdateCompanyCustomerResponse();
        }
    }
}

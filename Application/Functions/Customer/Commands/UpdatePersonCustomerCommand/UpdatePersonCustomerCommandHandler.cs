using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Customer.Commands.UpdatePersonCustomerCommand
{
    public class UpdatePersonCustomerCommandHandler : IRequestHandler<UpdatePersonCustomerCommand, UpdatePersonCustomerResponse>
    {
        private readonly IApplicationContext _context;

        public UpdatePersonCustomerCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdatePersonCustomerResponse> Handle(UpdatePersonCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePersonCustomerValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdatePersonCustomerResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedCustomer = await _context.Customers
                                                 .Where(p => p.IdCustomer == request.IdCustomer)
                                                 .SingleAsync();

            var selectedRepresentativeCustomer = await _context.Representatives
                                                               .Include(p => p.Customer)
                                                               .Where(p => p.IdCustomer == request.IdCustomer)
                                                               .Where(p => p.Name + " " + p.LastName == p.Customer.CompanyName)
                                                               .SingleOrDefaultAsync();

            if (selectedCustomer.CompanyName != request.Name + " " + request.LastName)
            {
                selectedCustomer.CompanyName = request.Name + " " + request.LastName;
                if (selectedRepresentativeCustomer != null)
                {
                    selectedRepresentativeCustomer.Name = request.Name;
                    selectedRepresentativeCustomer.LastName = request.LastName;
                }
            }
            if (selectedCustomer.CompanyPhoneNumber != request.CompanyPhoneNumber) { selectedCustomer.CompanyPhoneNumber = request.CompanyPhoneNumber; }
            if (selectedCustomer.CompanyEmailAddress != request.CompanyEmailAddress) { selectedCustomer.CompanyEmailAddress = request.CompanyEmailAddress; }
            if (selectedCustomer.IdWorker != request.IdWorker) { selectedCustomer.IdWorker = request.IdWorker; }

            await _context.SaveChangesAsync();

            return new UpdatePersonCustomerResponse();
        }
    }
}

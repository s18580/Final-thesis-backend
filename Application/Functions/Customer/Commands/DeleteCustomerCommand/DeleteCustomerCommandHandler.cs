using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Customer.Commands.DeleteCustomerCommand
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteCustomerCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteCustomerValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteCustomerResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var customerDelete = await _context.Customers
                                               .Where(p => p.IdCustomer == request.IdCustomer)
                                               .SingleAsync();

            _context.Customers.Remove(customerDelete);
            await _context.SaveChangesAsync();

            return new DeleteCustomerResponse();
        }
    }
}

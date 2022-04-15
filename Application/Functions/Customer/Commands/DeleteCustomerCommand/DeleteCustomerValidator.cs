using Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Customer.Commands.DeleteCustomerCommand
{
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerCommand>
    {
        private readonly IApplicationContext _context;

        public DeleteCustomerValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p).
                MustAsync(DoesCustomerExists)
                .WithMessage("Customer with given id does not exist.");
        }

        private async Task<bool> DoesCustomerExists(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers
                                         .Where(p => p.IdCustomer == command.IdCustomer)
                                         .SingleOrDefaultAsync();

            return customer != null;
        }
    }
}

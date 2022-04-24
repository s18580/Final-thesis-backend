using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.Supplier.Commands.CreateSupplierCommand
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, CreateSupplierResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateSupplierResponse> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSupplierValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateSupplierResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newSupplier = _mapper.Map<Domain.Models.Supplier>(request);

            await _context.Suppliers.AddAsync(newSupplier);
            await _context.SaveChangesAsync();

            return new CreateSupplierResponse(newSupplier.IdSupplier);
        }
    }
}

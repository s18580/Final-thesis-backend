using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Supplier.Commands.CreateSupplierCommand
{
    public class CreateSupplierResponse : BaseResponse
    {
        public int Id { get; }

        public CreateSupplierResponse(int id) : base()
        {
            Id = id;
        }

        public CreateSupplierResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateSupplierResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Supplier.Commands.CreateSupplierCommand
{
    public class CreateSupplierResponse : BaseResponse
    {
        public CreateSupplierResponse() : base()
        { }

        public CreateSupplierResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateSupplierResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

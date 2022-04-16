using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Supplier.Commands.DeleteSupplierCommand
{
    public class DeleteSupplierResponse : BaseResponse
    {
        public DeleteSupplierResponse() : base()
        { }

        public DeleteSupplierResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteSupplierResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

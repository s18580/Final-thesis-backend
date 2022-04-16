using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Supplier.Commands.UpdateSupplierCommand
{
    public class UpdateSupplierResponse : BaseResponse
    {
        public UpdateSupplierResponse() : base()
        { }

        public UpdateSupplierResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateSupplierResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

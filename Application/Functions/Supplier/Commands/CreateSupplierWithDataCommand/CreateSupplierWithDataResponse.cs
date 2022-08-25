using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Supplier.Commands.CreateSupplierWithDataCommand
{
    public class CreateSupplierWithDataResponse : BaseResponse
    {

        public CreateSupplierWithDataResponse() : base()
        { }

        public CreateSupplierWithDataResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateSupplierWithDataResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

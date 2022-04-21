using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Supply.Commands.DeleteSupplyCommand
{
    public class DeleteSupplyResponse : BaseResponse
    {
        public DeleteSupplyResponse() : base()
        { }

        public DeleteSupplyResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteSupplyResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

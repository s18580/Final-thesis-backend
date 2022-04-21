using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Supply.Commands.UpdateSupplyCommand
{
    public class UpdateSupplyResponse : BaseResponse
    {
        public UpdateSupplyResponse() : base()
        { }

        public UpdateSupplyResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateSupplyResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.BindingType.Commands.CreateBindingTypeCommand
{
    public class CreateBindingTypeResponse : BaseResponse
    {
        public CreateBindingTypeResponse() : base()
        { }

        public CreateBindingTypeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateBindingTypeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

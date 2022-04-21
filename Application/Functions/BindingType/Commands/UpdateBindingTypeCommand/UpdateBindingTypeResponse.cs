using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.BindingType.Commands.UpdateBindingTypeCommand
{
    public class UpdateBindingTypeResponse : BaseResponse
    {
        public UpdateBindingTypeResponse() : base()
        { }

        public UpdateBindingTypeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateBindingTypeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.BindingType.Commands.DeleteBindingTypeCommand
{
    public class DeleteBindingTypeResponse : BaseResponse
    {
        public DeleteBindingTypeResponse() : base()
        { }

        public DeleteBindingTypeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteBindingTypeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

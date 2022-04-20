using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Assignment.Commands.CreateAssignmentCommand
{
    public class CreateAssignmentResponse : BaseResponse
    {
        public CreateAssignmentResponse() : base()
        { }

        public CreateAssignmentResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateAssignmentResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

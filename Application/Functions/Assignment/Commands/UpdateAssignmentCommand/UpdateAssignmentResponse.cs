using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Assignment.Commands.UpdateAssignmentCommand
{
    public class UpdateAssignmentResponse : BaseResponse
    {
        public UpdateAssignmentResponse() : base()
        { }

        public UpdateAssignmentResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateAssignmentResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

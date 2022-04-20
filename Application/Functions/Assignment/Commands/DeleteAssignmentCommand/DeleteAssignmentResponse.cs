using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Assignment.Commands.DeleteAssignmentCommand
{
    public class DeleteAssignmentResponse : BaseResponse
    {
        public DeleteAssignmentResponse() : base()
        { }

        public DeleteAssignmentResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteAssignmentResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

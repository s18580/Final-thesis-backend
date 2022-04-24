using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Assignment.Commands.CreateAssignmentCommand
{
    public class CreateAssignmentResponse : BaseResponse
    {
        public int IdWorker { get; }
        public int IdOrder { get; }

        public CreateAssignmentResponse(int idWorker, int idOrder) : base()
        {
            IdWorker = idWorker;
            IdOrder = idOrder;
        }

        public CreateAssignmentResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateAssignmentResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

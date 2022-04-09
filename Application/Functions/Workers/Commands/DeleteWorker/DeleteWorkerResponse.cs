using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Workers.Commands.DeleteWorker
{
    public class DeleteWorkerResponse : BaseResponse
    {
        public DeleteWorkerResponse() : base()
        { }

        public DeleteWorkerResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteWorkerResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

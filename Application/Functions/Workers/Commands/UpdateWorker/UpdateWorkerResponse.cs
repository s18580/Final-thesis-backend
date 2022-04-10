using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Workers.Commands.UpdateWorker
{
    public class UpdateWorkerResponse : BaseResponse
    {
        public UpdateWorkerResponse() : base()
        { }

        public UpdateWorkerResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateWorkerResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

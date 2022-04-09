using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Workers.Commands.DisableWorker
{
    public class DisableWorkerResponse : BaseResponse
    {
        public DisableWorkerResponse() : base()
        { }

        public DisableWorkerResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DisableWorkerResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

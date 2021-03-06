using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Workers.Commands.CreateWorker
{
    public  class CreateWorkerResponse : BaseResponse
    {
        public int Id { get; }

        public CreateWorkerResponse(int id) : base()
        {
            Id = id;
        }

        public CreateWorkerResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateWorkerResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

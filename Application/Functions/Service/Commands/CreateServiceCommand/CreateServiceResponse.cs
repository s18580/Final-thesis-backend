using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Service.Commands.CreateServiceCommand
{
    public class CreateServiceResponse : BaseResponse
    {
        public int Id { get; }

        public CreateServiceResponse(int id) : base()
        {
            Id = id;
        }

        public CreateServiceResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateServiceResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.ServiceName.Commands.CreateServiceNameCommand
{
    public class CreateServiceNameResponse : BaseResponse
    {
        public int Id { get; }

        public CreateServiceNameResponse(int id) : base()
        {
            Id = id;
        }

        public CreateServiceNameResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateServiceNameResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

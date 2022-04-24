using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Address.Commands.CreateAddressCommand
{
    public class CreateAddressResponse : BaseResponse
    {
        public int Id { get; }

        public CreateAddressResponse(int id) : base()
        { 
            Id = id;
        }

        public CreateAddressResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateAddressResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

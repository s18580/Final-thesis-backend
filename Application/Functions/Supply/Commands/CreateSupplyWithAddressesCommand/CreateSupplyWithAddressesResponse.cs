using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Supply.Commands.CreateSupplyWithAddressesCommand
{
    public class CreateSupplyWithAddressesResponse : BaseResponse
    { 
        public CreateSupplyWithAddressesResponse() : base()
        { }

        public CreateSupplyWithAddressesResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateSupplyWithAddressesResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

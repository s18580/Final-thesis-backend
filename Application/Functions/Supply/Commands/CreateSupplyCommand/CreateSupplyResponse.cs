using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Supply.Commands.CreateSupplyCommand
{
    public class CreateSupplyResponse : BaseResponse
    {
        public int Id { get; }

        public CreateSupplyResponse(int id) : base()
        {
            Id = id;
        }

        public CreateSupplyResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateSupplyResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.SupplyItemType.Commands.CreateSupplyItemTypeCommand
{
    public class CreateSupplyItemTypeResponse : BaseResponse
    {
        public CreateSupplyItemTypeResponse() : base()
        { }

        public CreateSupplyItemTypeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateSupplyItemTypeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

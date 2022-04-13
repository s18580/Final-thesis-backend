using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.SupplyItemType.Commands.UpdateSupplyItemTypeCommand
{
    public class UpdateSupplyItemTypeResponse : BaseResponse
    {
        public UpdateSupplyItemTypeResponse() : base()
        { }

        public UpdateSupplyItemTypeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateSupplyItemTypeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

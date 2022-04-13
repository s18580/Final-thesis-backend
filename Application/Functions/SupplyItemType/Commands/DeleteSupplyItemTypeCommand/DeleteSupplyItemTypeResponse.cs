using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.SupplyItemType.Commands.DeleteSupplyItemTypeCommand
{
    public class DeleteSupplyItemTypeResponse : BaseResponse
    {
        public DeleteSupplyItemTypeResponse() : base()
        { }

        public DeleteSupplyItemTypeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteSupplyItemTypeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Worksites.Commands.UpdateWorksite
{
    public class UpdateWorksiteResponse : BaseResponse
    {
        public UpdateWorksiteResponse() : base()
        { }

        public UpdateWorksiteResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateWorksiteResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

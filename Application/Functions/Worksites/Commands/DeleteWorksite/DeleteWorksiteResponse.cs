using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Worksites.Commands.DeleteWorksite
{
    public class DeleteWorksiteResponse : BaseResponse
    {
        public DeleteWorksiteResponse() : base()
        { }

        public DeleteWorksiteResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteWorksiteResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

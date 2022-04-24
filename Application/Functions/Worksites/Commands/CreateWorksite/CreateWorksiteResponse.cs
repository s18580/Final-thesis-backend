using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Worksites.Commands.CreateWorksite
{
    public class CreateWorksiteResponse : BaseResponse
    {
        public int Id { get; }

        public CreateWorksiteResponse(int id) : base()
        {
            Id = id;
        }

        public CreateWorksiteResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateWorksiteResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

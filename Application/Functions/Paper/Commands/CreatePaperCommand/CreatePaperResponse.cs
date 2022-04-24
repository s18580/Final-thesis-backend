using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Paper.Commands.CreatePaperCommand
{
    public class CreatePaperResponse : BaseResponse
    {
        public int Id { get; }

        public CreatePaperResponse(int id) : base()
        {
            Id = id;
        }

        public CreatePaperResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreatePaperResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

using FluentValidation.Results;

namespace Application.Responses
{
    public class BaseResponse
    {
        public ResponseStatus Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }

        public BaseResponse()
        {
            ValidationErrors = new List<string>();
            Status = ResponseStatus.Success;
            Message = string.Empty;
            Success = true;
        }

        public BaseResponse(string message, bool success, ResponseStatus status)
        {
            ValidationErrors = new List<string>();
            Success = success;
            Message = message;
            Status = status;
        }

        public BaseResponse(ValidationResult validationResult, ResponseStatus status)
        {
            ValidationErrors = new List<String>();
            Success = validationResult.Errors.Count < 0;
            Message = string.Empty;
            Status = status;
            foreach (var item in validationResult.Errors)
            {
                ValidationErrors.Add(item.ErrorMessage);
                Message += (item.ErrorMessage + " ");
            }
        }
    }

    public enum ResponseStatus
    {
        Success = 0,
        NotFound = 1,
        BadQuery = 2,
        ValidationError = 3
    }
}

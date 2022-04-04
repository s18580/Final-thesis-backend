﻿using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Worksites.Commands.CreateWorksite
{
    public class CreateWorksiteResponse : BaseResponse
    {
        public CreateWorksiteResponse() : base()
        { }

        public CreateWorksiteResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public CreateWorksiteResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}

﻿using Application.Services;
using FluentValidation;

namespace Application.Functions.Supplier.Commands.CreateSupplierWithDataCommand
{
    public class CreateSupplierWithDataValidator : AbstractValidator<CreateSupplierWithDataCommand>
    {
        private readonly IApplicationContext _context;

        public CreateSupplierWithDataValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(p => p.Name)
                   .NotNull()
                   .WithMessage("Supplier name is required.")
                   .NotEmpty()
                   .WithMessage("Supplier name is required.")
                   .MaximumLength(255)
                   .WithMessage("Supplier name length can't be longer then 255 characters.");

            RuleFor(p => p.EmailAddress)
                   .NotNull()
                   .WithMessage("Email address can't be null.")
                   .MaximumLength(255)
                   .WithMessage("Email address length can't be longer then 255 characters.");

            RuleFor(p => p.Description)
                   .NotNull()
                   .WithMessage("Description can't be null.")
                   .MaximumLength(255)
                   .WithMessage("Description length can't be longer then 255 characters.");

            RuleFor(p => p.PhoneNumber)
                   .NotNull()
                   .WithMessage("Phone number can't be null.")
                   .MaximumLength(32)
                   .WithMessage("Phone number length can't be longer then 32 characters.");
        }
    }
}

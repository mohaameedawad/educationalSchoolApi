﻿using FluentValidation;
using SchoolCore.Features.Students.Commands.Models;
using SchoolServices.Interfaces;

namespace SchoolCore.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Properties
        private readonly IstudentService _studentService;
        #endregion

        #region Constructors
        public AddStudentValidator(IstudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("{PropertyValue} must not be null")
                .MaximumLength(10).WithMessage("{PropertyName} Length is 10");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyValue} must not be null")
                .MaximumLength(10).WithMessage("{PropertyName} Length is 10");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExist(key))
                .WithMessage("Name Is Exist");
        }
        #endregion
    }
}

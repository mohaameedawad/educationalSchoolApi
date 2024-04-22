using FluentValidation;
using SchoolCore.Features.Students.Commands.Models;

namespace SchoolCore.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Properties

        #endregion

        #region Constructors
        public AddStudentValidator()
        {
            ApplyValidationRules();
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
        #endregion
    }
}

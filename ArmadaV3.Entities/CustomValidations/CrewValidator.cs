using FluentValidation;

namespace ArmadaV3.Entities.CustomValidations
{
    public class CrewValidator : AbstractValidator<Crew>
    {
        public CrewValidator()
        {
            RuleFor(c => c.Number)
                .NotEmpty()
                .WithMessage("Required");


            RuleFor(c => c.Specialty)
                .NotEmpty()
                .WithMessage("Required")
                .Length(2, 50)
                .WithMessage("Length 2-50 characters");




        }
    }
}

using FluentValidation;


namespace ArmadaV3.Entities.CustomValidations
{
    public class EmperorValidator : AbstractValidator<Emperor>
    {
        public EmperorValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("Required")
                .Length(2, 50)
                .WithMessage("Length 2-50 characters")
                .Matches("^[a-zA-Z_ ]*$")
                .WithMessage("Only letters");

            RuleFor(e => e.Age)
                .NotEmpty()
                .WithMessage("Required");

            RuleFor(e => e.Description)
                .NotEmpty()
                .WithMessage("Required")
                .Length(2, 1000)
                .WithMessage("Length 2-1000 characters");
        }
    }
}

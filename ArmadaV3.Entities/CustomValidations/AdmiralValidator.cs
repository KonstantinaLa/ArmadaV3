using FluentValidation;

namespace ArmadaV3.Entities.CustomValidations
{
     public class AdmiralValidator: AbstractValidator<Admiral>
     {
        public AdmiralValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Required")
                .Length(2, 50)
                .WithMessage("Length 2-50 characters")
                .Matches("^[a-zA-Z_ ]*$")
                .WithMessage("Only letters");

            RuleFor(a => a.Age)
                .NotEmpty()
                .WithMessage("Required");

            RuleFor(a => a.EnlistmentDate)
                .NotEmpty()
                .WithMessage("Required");

            RuleFor(a => a.Description)
                .NotEmpty()
                .WithMessage("Required")
                .Length(2, 1000)
                .WithMessage("Length 2-1000 characters");

        }
     }
}

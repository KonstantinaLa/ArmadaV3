using FluentValidation;

namespace ArmadaV3.Entities.CustomValidations
{
    public class MissionValidator: AbstractValidator<Mission>
    {
        public MissionValidator()
        {
            RuleFor(m => m.Type)
               .NotEmpty()
                .WithMessage("Required")
                .Length(2, 50)
                .WithMessage("Length 2-50 characters")
                .Matches("^[a-zA-Z_ ]*$")
                .WithMessage("Only letters");

            RuleFor(a => a.StartDate)
                .NotEmpty()
                .WithMessage("Required");
            
            RuleFor(a => a.EndDate)
                .NotEmpty()
                .WithMessage("Required");
        }
    }
}

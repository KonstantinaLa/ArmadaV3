using FluentValidation;

namespace ArmadaV3.Entities.CustomValidations
{
    public class PlanetValidator : AbstractValidator<Planet>
    {
        public PlanetValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty()
               .WithMessage("Required")
               .Length(2, 50)
               .WithMessage("Length 2-50 characters")
               .Matches("^[a-zA-Z_ ]*$")
               .WithMessage("Only letters");

            RuleFor(p => p.StarSystem)
               .NotEmpty()
               .WithMessage("Required")
               .Length(2, 50)
               .WithMessage("Length 2-50 characters")
               .Matches("^[a-zA-Z_ ]*$")
               .WithMessage("Only letters");

            RuleFor(p => p.Type)
                .NotEmpty()
                .WithMessage("Required");
        }
    }
}

using ArmadaV3.Entities.CustomValidations;
using FluentValidation.Attributes;

namespace ArmadaV3.Entities
{
    [Validator(typeof(CrewValidator))]
    public class Crew
    {
        public int CrewId { get; set; }
        public int Number { get; set; }
        public string Specialty { get; set; }


        //Navigation Properties
        public virtual Admiral Admiral { get; set; }

    }
}
using System.Collections.Generic;
using ArmadaV3.Entities.CustomValidations;
using FluentValidation.Attributes;

namespace ArmadaV3.Entities
{
    [Validator(typeof(EmpireValidator))]
    public class Empire
    {
        public int EmpireId { get; set; }
        public string Name { get; set; }
        public string Trait { get; set; }
        public int ControlledSystems { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }


        //Navigation Properties
        public virtual Emperor Emperor { get; set; }
        public virtual ICollection<Admiral> Admirals { get; set; }
    }
}
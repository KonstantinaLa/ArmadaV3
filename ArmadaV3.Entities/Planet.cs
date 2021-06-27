using System.Collections.Generic;
using ArmadaV3.Entities.CustomValidations;
using FluentValidation.Attributes;

namespace ArmadaV3.Entities
{
    [Validator(typeof(PlanetValidator))]
    public class Planet
    {
        public int PlanetId { get; set; }
        public string Name { get; set; }
        public string StarSystem { get; set; }
        public PlanetType Type { get; set; }


        //Navigation Properties
        public virtual ICollection<Mission> Missions { get; set; }

        public Planet()
        {
            Missions = new HashSet<Mission>();
        }
    }
}
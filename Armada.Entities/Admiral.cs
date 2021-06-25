using System;
using System.Collections.Generic;

namespace Armada.Entities
{
    public class Admiral
    {
        public int AdmiralId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime EnlistmentDate { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public AdmiralSpecialty Specialty { get; set; }
        public EmperorSpecies Species { get; set; }


        //Navigation Properties

        public virtual ICollection<AdmiralMission> AdmiralMissions { get; set; }
        public virtual Empire Empire { get; set; }
        public int EmpireId { get; set; }
        public virtual Crew Crew { get; set; }

        public Admiral()
        {
            AdmiralMissions = new HashSet<AdmiralMission>();
        }
    }
}
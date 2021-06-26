using System;
using System.Collections.Generic;

namespace ArmadaV3.Entities
{
    public class Mission
    {
        public int MissionId { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Navigation Properties
        public virtual ICollection<AdmiralMission> AdmiralMissions { get; set; }
        public virtual ICollection<Planet> Planets { get; set; }

        public Mission()
        {
            Planets = new HashSet<Planet>();
            AdmiralMissions = new HashSet<AdmiralMission>();
        }
    }
}
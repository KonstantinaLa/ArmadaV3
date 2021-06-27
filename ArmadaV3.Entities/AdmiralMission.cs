using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArmadaV3.Entities
{
    public class AdmiralMission
    {
        
        public int UniqueNumberForSeed { get; set; }
        public int AdmiralId { get; set; }
        public int MissionId { get; set; }
        public Admiral Admiral { get; set; }
        public Mission Mission { get; set; }

        public bool? IsSuccess { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace ArmadaV3.Entities
{
    public class Crew
    {
        public int CrewId { get; set; }
        public int Number { get; set; }
        public string Specialty { get; set; }


        //Navigation Properties
        public virtual Admiral Admiral { get; set; }

    }
}
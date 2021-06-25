using System.Collections.Generic;

namespace Armada.Entities
{
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
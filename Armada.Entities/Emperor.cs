using System.ComponentModel.DataAnnotations.Schema;

namespace Armada.Entities
{
    public class Emperor
    {
        public int EmperorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public EmperorSpecies Species { get; set; }


        //Navigation Properties
        public virtual Empire Empire { get; set; }
    }
}

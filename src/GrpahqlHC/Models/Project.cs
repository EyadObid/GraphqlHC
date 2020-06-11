using System.Collections.Generic;

namespace GrpahqlHC.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Lot> Lots { get; set; } = new List<Lot>();
    }
}

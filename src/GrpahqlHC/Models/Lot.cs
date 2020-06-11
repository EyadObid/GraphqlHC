using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrpahqlHC.Models
{
    public class Lot
    {
        public int Id { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public int Number { get; set; }

        public string Address { get; set; }

        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}

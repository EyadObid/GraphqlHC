using System.ComponentModel.DataAnnotations.Schema;

namespace GrpahqlHC.Models
{
    public class Note
    {
        public int Id { get; set; }

        [ForeignKey("Lot")]
        public int LotId { get; set; }

        public Lot Lot { get; set; }

        public string Comment { get; set; }
    }
}

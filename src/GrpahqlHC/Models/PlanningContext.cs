using Microsoft.EntityFrameworkCore;

namespace GrpahqlHC.Models
{
    public class PlanningContext : DbContext
    {
        public PlanningContext(DbContextOptions<PlanningContext> options)
            : base(options)
        { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}

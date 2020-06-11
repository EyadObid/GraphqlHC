using Microsoft.EntityFrameworkCore;

namespace GrpahqlHC.Models
{
    public class PlanningDbContext : DbContext
    {
        public PlanningDbContext(DbContextOptions<PlanningDbContext> options)
            : base(options)
        { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}

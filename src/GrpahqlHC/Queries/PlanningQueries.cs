using GrpahqlHC.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace GrpahqlHC.Queries
{
    public class PlanningQueries
    {
        [UseSelection]
        public IQueryable<Project> GetProjects([Service] PlanningDbContext dbContext) => dbContext.Projects;

        [UseSelection]
        public IQueryable<Project> GetProject([Service] PlanningDbContext dbContext, int id) => dbContext.Projects.Where(x => x.Id == id);
    }
}

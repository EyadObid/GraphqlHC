using GrpahqlHC.Models;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GrpahqlHC.Subscriptions
{
    public class Subscriptions
    {
        public async Task<Lot> OnLotUpdatedAsync(int id, [Service] PlanningDbContext dbContext)
        {
            Lot lot = await dbContext.Lots.FirstOrDefaultAsync(_ => _.Id == id);
            return lot;
        }
    }
}

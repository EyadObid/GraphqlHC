using GrpahqlHC.Events;
using GrpahqlHC.Models;
using HotChocolate;
using HotChocolate.Subscriptions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GrpahqlHC.Mutations
{
    public class Mutations
    {
        public async Task<Lot> UpdateLotAsync([Service] PlanningDbContext dbContext, [Service] IEventSender eventSender, Lot lot)
        {
            Lot currentLot = await dbContext.Lots.FirstOrDefaultAsync(_ => _.Id == lot.Id);
            currentLot.Number = lot.Number;
            await dbContext.SaveChangesAsync();

            await eventSender.SendAsync(new LotUpdatedEvent(currentLot.Id));

            return currentLot;
        }
    }
}

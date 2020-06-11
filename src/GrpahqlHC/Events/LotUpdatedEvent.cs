using HotChocolate.Language;
using HotChocolate.Subscriptions;

namespace GrpahqlHC.Events
{
    public class LotUpdatedEvent : EventMessage
    {
        public LotUpdatedEvent(int id) : base(CreateEventDescription(id))
        {
        }

        private static EventDescription CreateEventDescription(int id)
        {
            return new EventDescription("onLotUpdated",
                new ArgumentNode("id",
                    new IntValueNode(id)));
        }
    }
}

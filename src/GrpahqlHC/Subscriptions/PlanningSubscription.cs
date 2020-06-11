using GrpahqlHC.Types;
using HotChocolate.Types;

namespace GrpahqlHC.Subscriptions
{
    public class PlanningSubscription : ObjectType<Subscriptions>
    {
        protected override void Configure(IObjectTypeDescriptor<Subscriptions> descriptor)
        {
            descriptor.Field(_ => _.OnLotUpdatedAsync(default, default))
                .Type<NonNullType<LotType>>()
                .Argument("id", _ => _.Type<IntType>());
        }
    }
}

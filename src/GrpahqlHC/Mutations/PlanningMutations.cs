using GrpahqlHC.Types;
using HotChocolate.Types;

namespace GrpahqlHC.Mutations
{
    public class PlanningMutations : ObjectType<Mutations>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutations> descriptor)
        {
            descriptor.Field(_ => _.UpdateLotAsync(default, default, default))
                .Type<NonNullType<LotType>>()
                .Argument("lot", _ => _.Type<NonNullType<LotInputType>>());
        }
    }
}

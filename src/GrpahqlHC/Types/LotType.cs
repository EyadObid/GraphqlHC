using GrpahqlHC.Models;
using HotChocolate.Types;

namespace GrpahqlHC.Types
{
    public class LotType : ObjectType<Lot>
    {
        protected override void Configure(IObjectTypeDescriptor<Lot> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(_ => _.Id).Description("The unique identifier of the lot");
            descriptor.Field(_ => _.Number).Description("The number of the lot");
            descriptor.Field(_ => _.Address).Description("The address of the lot");
            descriptor.Field(_ => _.Notes).Type<ListType<NoteType>>();
        }
    }
}

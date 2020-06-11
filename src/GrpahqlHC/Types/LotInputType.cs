using GrpahqlHC.Models;
using HotChocolate.Types;

namespace GrpahqlHC.Types
{
    public class LotInputType : InputObjectType<Lot>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Lot> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.Number);
        }
    }
}

using GrpahqlHC.Models;
using HotChocolate.Types;

namespace GrpahqlHC.Types
{
    public class ProjectType : ObjectType<Project>
    {
        protected override void Configure(IObjectTypeDescriptor<Project> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(_ => _.Id).Description("The unique identifier of the project");
            descriptor.Field(_ => _.Name).Description("The name of the project");
            descriptor.Field(_ => _.Lots).Type<ListType<LotType>>();
        }
    }
}

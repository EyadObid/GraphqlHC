using GrpahqlHC.Models;
using HotChocolate.Types;

namespace GrpahqlHC.Types
{
    public class NoteType : ObjectType<Note>
    {
        protected override void Configure(IObjectTypeDescriptor<Note> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(_ => _.Id).Description("The unique identifier of the note");
            descriptor.Field(_ => _.Comment).Description("The comment of the note");
        }
    }
}

using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Commands.ParentCommands
{
    public class UpdateParentCammand : IRequest<bool>
    {
        public Parent parent { get; set; }
        public UpdateParentCammand(Parent parent)
        {
            this.parent = parent;
        }
    }
}

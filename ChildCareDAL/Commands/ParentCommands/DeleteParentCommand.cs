using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Commands.ParentCommands
{
    public class DeleteParentCommand : IRequest<int>
    {
        public Parent? Parent { get; set; }

        public DeleteParentCommand(Parent? parent)
        {
            Parent = parent;
        }
    }
}

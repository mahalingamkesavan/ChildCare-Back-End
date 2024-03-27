using businessServicess.models.RequestModels.ChildCare;
using MediatR;
namespace ChildCareDAL.Commands.ParentCommands
{
    public class CreateParentCommand : IRequest<(bool, Parent)>
    {
        public Parent Parent { get; set; }
        public CreateParentCommand(Parent parent)
        {
            this.Parent = parent;
        }
    }
}

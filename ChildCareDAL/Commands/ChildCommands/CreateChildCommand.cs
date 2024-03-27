using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Commands.ChildCommands
{
    public class CreateChildCommand : IRequest<(bool, Child)>
    {
        public Child Child { get; set; }
        public CreateChildCommand(Child child)
        {
            Child = child;
        }
    }
}

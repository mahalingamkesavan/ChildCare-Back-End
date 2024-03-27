using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Commands.ChildCommands
{
    public class DeleteChildCommand : IRequest<int>
    {
        public Child Child { get; set; }
        public DeleteChildCommand(Child child)
        {
            Child = child;
        }
    }
}

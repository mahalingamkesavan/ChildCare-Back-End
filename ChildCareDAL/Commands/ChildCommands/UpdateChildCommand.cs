using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Commands.ChildCommands
{
    public class UpdateChildCommand : IRequest<bool>
    {
        public Child Child { get; set; }
        public UpdateChildCommand(Child child)
        {
            Child = child;
        }
    }
}

using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.Commands.ChildCommands;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Handler.HandlerChild
{
    public class CreateChildHandler : IRequestHandler<CreateChildCommand, (bool, Child)>
    {
        private readonly IChildDAL childDAL;
        public CreateChildHandler(IChildDAL childDAL)
        {
            this.childDAL = childDAL;
        }

        public Task<(bool, Child)> Handle(CreateChildCommand request, CancellationToken cancellationToken)
        {
            return childDAL.Add(request.Child);
        }
    }
}

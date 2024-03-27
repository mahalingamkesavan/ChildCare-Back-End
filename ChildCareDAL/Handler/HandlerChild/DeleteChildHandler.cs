using ChildCareDAL.Commands.ChildCommands;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Handler.HandlerChild
{
    public class DeleteChildHandler : IRequestHandler<DeleteChildCommand, int>
    {
        private readonly IChildDAL childDAL;

        public DeleteChildHandler(IChildDAL childDAL)
        {
            this.childDAL = childDAL;
        }

        public Task<int> Handle(DeleteChildCommand request, CancellationToken cancellationToken)
        {
            return childDAL.Delete(request.Child);
        }
    }
}

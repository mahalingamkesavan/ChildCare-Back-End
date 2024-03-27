using ChildCareDAL.Commands.ChildCommands;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Handler.HandlerChild
{
    internal class UpdateChildHandler : IRequestHandler<UpdateChildCommand, bool>
    {
        private readonly IChildDAL childDAL;
        public UpdateChildHandler(IChildDAL childDAL)
        {
            this.childDAL = childDAL;
        }

        public Task<bool> Handle(UpdateChildCommand request, CancellationToken cancellationToken)
        {
            return childDAL.Update(request.Child);
        }
    }
}

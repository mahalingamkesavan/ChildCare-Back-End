using ChildCareDAL.Commands.ParentCommands;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

#nullable disable

namespace ChildCareDAL.Handler.HandlerParent
{
    public class DeleteParentHandler : IRequestHandler<DeleteParentCommand, int>
    {
        private readonly IParentDAL parentDAL;
        public DeleteParentHandler(IParentDAL parentDAL)
        {
            this.parentDAL = parentDAL;
        }
        public async Task<int> Handle(DeleteParentCommand request, CancellationToken cancellationToken)
        {
            return await parentDAL.Delete(request.Parent);
        }
    }
}

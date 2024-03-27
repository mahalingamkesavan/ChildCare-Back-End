using ChildCareDAL.Commands.ParentCommands;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Handler.HandlerParent
{
    public class UpdateParentHandler : IRequestHandler<UpdateParentCammand, bool>
    {
        private readonly IParentDAL _parentDAL;
        public UpdateParentHandler(IParentDAL parentDAL)
        {
            _parentDAL = parentDAL;
        }
        public Task<bool> Handle(UpdateParentCammand request, CancellationToken cancellationToken)
        {
            return _parentDAL.Update(request.parent);
        }
    }
}

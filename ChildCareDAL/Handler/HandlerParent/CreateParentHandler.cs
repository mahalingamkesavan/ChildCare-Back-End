using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.Commands.ParentCommands;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Handler.HandlerParent
{
    public class CreateParentHandler : IRequestHandler<CreateParentCommand, (bool, Parent)>
    {
        private readonly IParentDAL _parentDAL;
        public CreateParentHandler(IParentDAL parentDAL)
        {
            _parentDAL = parentDAL;
        }
        public async Task<(bool, Parent)> Handle(CreateParentCommand request, CancellationToken cancellationToken)
        {
            return await _parentDAL.Add(request.Parent);
        }
    }
}

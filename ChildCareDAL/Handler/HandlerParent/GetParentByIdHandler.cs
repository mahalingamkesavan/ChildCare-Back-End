using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.Querys.QueryParent;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Handler.HandlerParent
{
    public class GetParentByIdHandler : IRequestHandler<GetParentByIdQuery, Parent>
    {
        private readonly IParentDAL _parentDAL;
        public GetParentByIdHandler(IParentDAL parentDAL) { _parentDAL = parentDAL; }

        public async Task<Parent> Handle(GetParentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _parentDAL.Get(x => x.Id == request.Id);
        }
    }
}

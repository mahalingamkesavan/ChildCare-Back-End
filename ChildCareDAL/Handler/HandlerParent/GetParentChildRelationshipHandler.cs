using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.Querys.QueryParent;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Handler.HandlerParent
{
    public class GetParentChildRelationshipHandler : IRequestHandler<GetparenrtchildByIdQuery, ParentChildDetailDTO>
    {
        private readonly IParentDAL parentDAL;
        public GetParentChildRelationshipHandler(IParentDAL parentDAL)
        {
            this.parentDAL = parentDAL;
        }
        public async Task<ParentChildDetailDTO> Handle(GetparenrtchildByIdQuery request, CancellationToken cancellationToken)
        {
            return await parentDAL.GetParentChildRelationship(request.Id);
        }
    }
}

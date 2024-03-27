using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Querys.QueryParent
{
    public class GetParentListQuery : IRequest<List<Parent>>
    {
        public string? request { get; set; }
    }
}

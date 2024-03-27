using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Querys.QueryChild
{
    public class GetChildListQuery : IRequest<List<Child>>
    {
        public string? request { get; set; }
    }
}

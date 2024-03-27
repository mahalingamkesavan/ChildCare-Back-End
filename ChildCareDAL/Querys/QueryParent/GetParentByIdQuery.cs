using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Querys.QueryParent
{
    public class GetParentByIdQuery : IRequest<Parent>
    {
        public int Id { get; set; }
    }
}

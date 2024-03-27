using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Querys.QueryParent
{
    public class GetparenrtchildByIdQuery : IRequest<ParentChildDetailDTO>
    {
        public int Id { get; set; }
    }
}

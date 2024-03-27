using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Querys.QueryChild
{
    public class GetChildByIdQuery : IRequest<Child>
    {
        public int Id { get; set; }
    }
}

using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Querys.QueryEnrollment
{
    public class GetEnrollmentByIdQuery : IRequest<ChildEnrollment>
    {
        public int Id { get; set; }
    }
}

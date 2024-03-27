using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Querys.QueryEnrollment
{
    public class GetEnrollmentListQuery : IRequest<List<ChildEnrollment>>
    {
        public string? request { get; set; }
    }
}

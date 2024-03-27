
using businessServicess.models.RequestModels.ChildCare;

namespace businessServicess.models.RequestModels.auth
{
    public class EnrollmentApproveStatus
    {
        public int EnrollmentStatusId { get; set; }
        public EnrollmentRequest? enrollmentId { get; set; }
        public string? status { get; set; }


    }
}

using businessServicess.models.RequestModels.ChildCare;
#nullable disable


namespace businessServicess.models.ResponseModel
{
    public class GetEnrollmentList : ResultDTO
    {
        public List<ChildEnrollment> entrollmentslist { get; set; }
    }
}

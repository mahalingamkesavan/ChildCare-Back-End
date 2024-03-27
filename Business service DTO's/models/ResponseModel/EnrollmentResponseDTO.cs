using businessServicess.models.RequestModels.ChildCare;
#nullable disable

namespace businessServicess.models.ResponseModel
{
    public class EnrollmentResponseDTO : ResultDTO
    {
        public Parent parentData { get; set; }

        public Child childData { get; set; }

        public ChildEnrollment childEntrollmentData { get; set; }
    }
}

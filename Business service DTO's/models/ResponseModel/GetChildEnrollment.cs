using businessServicess.models.RequestModels.ChildCare;

#nullable disable
namespace businessServicess.models.ResponseModel
{
    public class GetChildEnrollment : ResultDTO
    {
        public ChildEnrollment childEntrollment { get; set; }
    }
}

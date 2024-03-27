#nullable disable


using businessServicess.models.ResponseModel;

namespace businessServicess.models.RequestModels.ChildCare
{
    public class ParentChildDetailDTO
    {
        public Parent Parent { get; set; }
        public List<Child> ChildList { get; set; }
    }
    public class ParentChildDetailResponseDTO : ResultDTO
    {
        public ParentChildDetailDTO ParentChildData { get; set; }

    }

}

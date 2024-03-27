
#nullable disable

using businessServicess.models.RequestModels.ChildCare;

namespace businessServicess.models.ResponseModel
{
    public class ResponseParentDTO : ResultDTO
    {
        public Parent parent { get; set; }
    }
    public class ResponseParentListDTO : ResultDTO
    {
        public List<Parent> parent { get; set; }
    }
    public class Response : ResultDTO
    {
        public string id { get; set; }
    }
    public class Responseparent : ResultDTO
    {
        public object parent { get; set; }
    }

}

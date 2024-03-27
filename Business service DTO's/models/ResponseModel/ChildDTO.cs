using businessServicess.models.RequestModels.ChildCare;


#nullable disable
namespace businessServicess.models.ResponseModel
{

    public class ResponseChildDTO : ResultDTO
    {
        public Child child { get; set; }
        // public ChildResponce child { get; set; }
    }
    public class ResponceChildListDTO : ResultDTO
    {
        // public List<ChildResponce> ChildList { get; set; }
        public List<Child> ChildList { get; set; }
    }

}

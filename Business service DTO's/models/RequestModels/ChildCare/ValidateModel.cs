
namespace businessServicess.models.RequestModels.ChildCare
{
    public class ValidateModel
    {
        public bool Isvalid { get; set; }
        public List<string>? Massage { get; set; }
        public ValidateModel()
        {
            List<string>? Massage = new List<string>();
        }
    }
}

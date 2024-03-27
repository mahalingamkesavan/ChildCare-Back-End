namespace businessServicess.models.ResponseModel
{
    public class ChildProfileResponceDTO
    {
        public List<ChildProfileDTO>? ChildProfiles { get; set; }
        public ChildProfileResponceDTO()
        {
            List<ChildProfileDTO>? ChildProfiles = new List<ChildProfileDTO>();
        }
    }
}

using Microsoft.AspNetCore.Http;
#nullable disable

namespace businessServicess.models.RequestModels.ChildCare
{
    public class ParentDTO : Parent
    {
        public IFormFile UserImageUrl { get; set; } = null;
    }
}

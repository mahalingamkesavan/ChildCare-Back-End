using Microsoft.AspNetCore.Http;
#nullable disable

namespace businessServicess.models.RequestModels.ChildCare
{
    public class FileUploadModel
    {
        public int EnrollmentId { get; set; }
        public IFormFile FileDetails { get; set; }
    }

    public class FileUploadResponceDTO :FileUploadModel
    {
        public int FileId { get; set; }
    }
}

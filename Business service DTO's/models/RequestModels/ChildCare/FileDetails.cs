using System.ComponentModel.DataAnnotations;

#nullable disable
namespace businessServicess.models.RequestModels.ChildCare
{
    public class FileDetails
    {
        [Key]
        public int ID { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public int EnrollmentId { get; set; }
    }

}

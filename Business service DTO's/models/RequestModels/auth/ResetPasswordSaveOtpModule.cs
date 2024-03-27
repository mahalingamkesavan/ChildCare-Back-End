using System.ComponentModel.DataAnnotations;

namespace businessServicess.models.RequestModels.auth
{
    public class ResetPasswordSaveTokenModule
    {
        [Key]
        public int Id { get; set; }
        public long RandomNumber { get; set; }
        public string? UserId { get; set; }
    }
}

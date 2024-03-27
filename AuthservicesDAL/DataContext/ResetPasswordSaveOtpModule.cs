using System.ComponentModel.DataAnnotations;

namespace AuthservicesDAL.DataContext
{
    public class ResetPasswordSaveOtpModule
    {

        [Key]
        public int Id { get; set; }
        public long RandomNumber { get; set; }
        public string? UserId { get; set; }
    }
}

namespace businessServicess.models.RequestModels.auth
{
    public class ChangePassword
    {
        public string? UserName { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}

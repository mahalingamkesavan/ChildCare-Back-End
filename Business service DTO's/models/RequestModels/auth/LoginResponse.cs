namespace businessServicess.models.RequestModels.auth
{
    public class LoginResponse
    {
        public string? token { get; set; }
        public DateTime? expiration { get; set; }
        public List<string>? roles { get; set; }
        public string? Username { get; set; }
    }
}

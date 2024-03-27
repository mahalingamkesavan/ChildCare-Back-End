namespace businessServicess.models.RequestModels.auth
{
    public class ResertPasswortwithOtp : ChangePassword
    {
        public object applicationCantext { get; set; }

        public ResertPasswortwithOtp()
        {
            applicationCantext = new object();

        }
    }
}

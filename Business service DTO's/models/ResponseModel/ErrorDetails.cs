using System.Text.Json;
#nullable disable

namespace businessServicess.models.ResponseModel
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

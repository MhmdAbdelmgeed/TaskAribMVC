using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskAribMVC.Shared.Response
{
    public class ResponseDTO
    {
        [Required]
        public int StatusCodes { get; set; }

        public string Message { get; set; } = string.Empty;

        public string Error { get; set; } = string.Empty;


        public string Token { get; set; } = string.Empty;

        public DateTime ExpiredOn { get; set; }
        public string UserId { get; set; }

        [JsonIgnore]
        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiration { get; set; }
    }

}

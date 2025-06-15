

namespace eShopApi.Models.Entities
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; } = 500;
        public string Status { get; set; } = "Internal Server Error";
        public string Message { get; set; } = "An unexpected error occurred.";
        public string? StackTrace { get; set; }
    }
}
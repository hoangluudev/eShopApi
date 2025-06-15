using System.Net;
using eShopApi.Models.Entities;


namespace eShopApi.Middlewares
{
    public class Global404RouteHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<Global404RouteHandler> _logger;

        public Global404RouteHandler(RequestDelegate next, ILogger<Global404RouteHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Chuyển yêu cầu đến middleware tiếp theo.
            // Nếu không có middleware nào sau nó xử lý yêu cầu (nghĩa là không tìm thấy route khớp),
            // thì hàm InvokeAsync của middleware này sẽ được gọi lại sau khi tất cả các middleware khác đã chạy.
            await _next(context);

            // Kiểm tra nếu mã trạng thái phản hồi là 404 và chưa có nội dung nào được ghi.
            // Điều này xảy ra khi không có route nào khớp yêu cầu.
            if (context.Response.StatusCode == (int)HttpStatusCode.NotFound && !context.Response.HasStarted)
            {
                _logger.LogWarning("Yêu cầu không tìm thấy: {Path}{QueryString}", context.Request.Path, context.Request.QueryString);

                context.Response.ContentType = "application/json";
                var path = context.Request.Path;
                var query = context.Request.QueryString;

                var errorResponse = new ErrorResponse
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Status = "Not Found",
                    Message = $"Can't find {path}{query} on the server!"
                };

                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
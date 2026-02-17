using insights_backend.Builder;
using insights_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace insights_backend.Controllers
{
    // Controller for handling push notification related endpoints
    [ApiController]
    [Route("api/[controller]/send")]
    public class NotificationController : ControllerBase
    {
        private readonly IPushNotificationService _pushNotificationService;

        public NotificationController(IPushNotificationService pushNotificationService)
        {
            _pushNotificationService = pushNotificationService;
        }

        [HttpPost]
        public async Task<IActionResult> SendPushNotification([FromBody] INotificationPayloadBuilder payloadBuilder)
        {
            try
            {
                await _pushNotificationService.SendAsync(payloadBuilder);
                return Ok(new { Message = "Notification sent successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, new { Message = "An error occurred while sending the notification", Details = ex.Message });
            }
        }

    }
}

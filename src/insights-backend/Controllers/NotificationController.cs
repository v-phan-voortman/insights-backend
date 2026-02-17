using Microsoft.AspNetCore.Mvc;
using insights_backend.Models;
using insights_backend.Builders;
using insights_backend.Services;

namespace insights_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly PushNotificationService _pushService;

    public NotificationsController(PushNotificationService pushService)
    {
        _pushService = pushService;
    }

    [HttpGet("ping")]
    public IActionResult Ping() => Ok("working");

    [HttpPost("send")]
    public async Task<IActionResult> Send([FromBody] PushNotificationRequest request)
    {
        try
        {
            var builder = new BasicNotification(request);
            var messageId = await _pushService.SendAsync(builder);
            return Ok(new { success = true, messageId });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, error = ex.Message });
        }
    }

    [HttpPost("send-multicast")]
    public async Task<IActionResult> SendMulticast([FromBody] PushNotificationRequest request)
    {
        try
        {
            if (request.DeviceTokens == null || request.DeviceTokens.Count == 0)
                return BadRequest(new { success = false, error = "DeviceTokens is required" });

            var builder = new BasicNotification(request);
            var response = await _pushService.SendMulticastAsync(builder);

            return Ok(new
            {
                success = true,
                successCount = response.SuccessCount,
                failureCount = response.FailureCount
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, error = ex.Message });
        }
    }
}
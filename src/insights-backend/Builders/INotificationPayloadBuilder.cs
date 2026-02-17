using insights_backend.Models;

namespace insights_backend.Builders;

public interface INotificationPayloadBuilder
{
    PushNotificationRequest BuildPayload();
}
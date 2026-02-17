using insights_backend.Models;

namespace insights_backend.Builder
{
    // Interface for building notification payloads
    public interface INotificationPayloadBuilder
    {
        PushNotificationRequest BuildPayload();
    }
}

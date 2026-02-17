using insights_backend.Models;

namespace insights_backend.Builders;

public class BasicNotification : INotificationPayloadBuilder
{
    private readonly PushNotificationRequest _request;

    public BasicNotification(PushNotificationRequest request)
    {
        _request = request;
    }

    public PushNotificationRequest BuildPayload()
    {
        return _request;
    }
}
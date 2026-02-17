using FirebaseAdmin.Messaging;
using insights_backend.Builders;
using insights_backend.Models;

namespace insights_backend.Services;

public class PushNotificationService : IPushNotificationService
{
    private readonly FirebaseMessaging _messaging;

    public PushNotificationService()
    {
        _messaging = FirebaseMessaging.DefaultInstance;
    }

    public async Task<string> SendAsync(INotificationPayloadBuilder builder)
    {
        var request = builder.BuildPayload();
        var message = BuildMessage(request);
        return await _messaging.SendAsync(message);
    }

    public async Task<BatchResponse> SendMulticastAsync(INotificationPayloadBuilder builder)
    {
        var request = builder.BuildPayload();

        var multicast = new MulticastMessage
        {
            Tokens = request.DeviceTokens,
            Notification = new Notification
            {
                Title = request.Title,
                Body = request.Body,
                ImageUrl = request.ImageUrl
            },
            Data = request.Data,
            Android = BuildAndroidConfig(),
            Apns = BuildApnsConfig()
        };

        return await _messaging.SendEachForMulticastAsync(multicast);
    }

    private Message BuildMessage(PushNotificationRequest request)
    {
        var message = new Message
        {
            Notification = new Notification
            {
                Title = request.Title,
                Body = request.Body,
                ImageUrl = request.ImageUrl
            },
            Data = request.Data,
            Android = BuildAndroidConfig(),
            Apns = BuildApnsConfig()
        };

        // Set targeting - only one should be set
        if (!string.IsNullOrEmpty(request.DeviceToken))
            message.Token = request.DeviceToken;
        else if (!string.IsNullOrEmpty(request.Topic))
            message.Topic = request.Topic;
        else if (!string.IsNullOrEmpty(request.Condition))
            message.Condition = request.Condition;

        return message;
    }

    private AndroidConfig BuildAndroidConfig()
    {
        return new AndroidConfig
        {
            Priority = Priority.High,
            Notification = new AndroidNotification
            {
                Sound = "default",
                ChannelId = "default_channel"
            }
        };
    }

    private ApnsConfig BuildApnsConfig()
    {
        return new ApnsConfig
        {
            Aps = new Aps
            {
                Sound = "default",
                Badge = 1
            }
        };
    }

}
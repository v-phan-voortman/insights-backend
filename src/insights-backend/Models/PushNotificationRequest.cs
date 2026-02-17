using FirebaseAdmin.Messaging;

namespace insights_backend.Models;

// Model representing the request payload for sending a push notification
public class PushNotificationRequest 
{

    // Targeting information
    public string? DeviceToken { get; set; } // For direct device targeting
    public string? Topic { get; set; } // For topic-based targeting
    public string? Condition { get; set; } // For condition-based targeting
    public List<string>? DeviceTokens { get; set; } // For multiple device targeting

    // Common fields for all notifications
    public required string Title { get; set; } // Notification title
    public required string Body { get; set; } // Notification body
    public string? ImageUrl { get; set; } // Optional image URL for the notification
    public required IReadOnlyDictionary<string, string> Data { get; set; } // Custom data payload for the notification

    // Platform-specific fields
    public AndroidConfig? AndroidConfig { get; set; } // Android-specific configuration
    public ApnsConfig? ApnsConfig { get; set; } // iOS-specific configuration

}

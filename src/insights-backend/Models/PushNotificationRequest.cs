using FirebaseAdmin.Messaging;

namespace insights_backend.Models;

// Model representing the request payload for sending a push notification
public class PushNotificationRequest
{
    // Targeting fields - only one should be set
    public string? DeviceToken { get; set; } // Target a specific device
    public string? Topic { get; set; } = null; // Target devices subscribed to a topic
    public string? Condition { get; set; } = null; // Target devices based on conditions (e.g., "'TopicA' in topics && 'TopicB' in topics")
    public List<string>? DeviceTokens { get; set; } // Target multiple devices (used for multicast)

    // Notification content
    public required string Title { get; set; } // Notification title
    public required string Body { get; set; } // Notification body
    public string? ImageUrl { get; set; } = null; // Optional URL for an image to include in the notification
    public required Dictionary<string, string> Data { get; set; } // Custom key-value pairs to include in the notification payload

    // Optional configuration fields
    public string? Type { get; set; } = null; // Optional field to specify the type of notification (e.g., "alert", "reminder", "update") for client-side handling
}
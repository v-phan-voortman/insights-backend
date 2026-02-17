using FirebaseAdmin.Messaging;
using insights_backend.Builders;
using insights_backend.Models;

namespace insights_backend.Services
{
    /* 
     * The IPushNotificationService interface defines the contract for sending push notifications using Firebase Cloud Messaging (FCM).
     */
    public interface IPushNotificationService
    {
        // Method to send a push notification based on the provided request
        Task<string> SendAsync(INotificationPayloadBuilder builder);
        // Method to send multiple push notifications in a batch
        Task<BatchResponse> SendMulticastAsync(INotificationPayloadBuilder builder);
    }
}

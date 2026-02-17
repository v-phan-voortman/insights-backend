using FirebaseAdmin.Messaging;
using insights_backend.Builder;
using insights_backend.Models;

namespace insights_backend.Services
{
    public class PushNotificationService : IPushNotificationService
    {
        private readonly FirebaseMessaging _firebaseMessaging;

        public PushNotificationService(FirebaseMessaging firebaseMessaging)
        {
            _firebaseMessaging = firebaseMessaging;
        }
        public Task SendAsync(INotificationPayloadBuilder builder)
        {
            var request = builder.BuildPayload();
            var message = MapToFirebaseMessage(request);
            return _firebaseMessaging.SendAsync(message);

        }

        private Message MapToFirebaseMessage(PushNotificationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<BatchResponse> SendMulticastAsync(INotificationPayloadBuilder builder)
        {
            var request = builder.BuildPayload();
            var message = MapToFirebaseMulticast(request);
            return _firebaseMessaging.SendEachForMulticastAsync(message);
        }

        private MulticastMessage MapToFirebaseMulticast(PushNotificationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

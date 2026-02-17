using System.Collections.Generic;
using insights_backend.Models;

namespace insights_backend.Builder
{
    public class BasicNotification : INotificationPayloadBuilder
    {
        public PushNotificationRequest BuildPayload()
        {
            return new PushNotificationRequest
            {
                DeviceToken = "fDiu_26TRjyHdhjfc1nKqZ:APA91bFzNjmxZAelRkJbLyQoxk2c_zHeVL_BoJfi21EMekL6p_P1E7_jMcbyQy-MQUXCp4AQoiW5NtVUyfX6IUCK0vcceoFFoC2hno96XY5iVm6NrT4roFo",
                Title = "Basic Notification",
                Body = "This is a basic notification without any additional configuration.",
                Data = new Dictionary<string, string>
                {
                    { "key1", "value1" }
                },
            };
        }
    }
}

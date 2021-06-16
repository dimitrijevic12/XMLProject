using NotificationMicroservice.Api.DTOs;

namespace NotificationMicroservice.Api.Factories
{
    public class NotificationOptionsFactory
    {
        public NotificationOptions Create(Core.Model.NotificationOptions notificationOptions)
        {
            return new NotificationOptions
            {
                Id = notificationOptions.Id,
                IsNotifiedByFollowRequests = notificationOptions.IsNotifiedByFollowRequests,
                IsNotifiedByMessages = notificationOptions.IsNotifiedByMessages,
                IsNotifiedByPosts = notificationOptions.IsNotifiedByPosts,
                IsNotifiedByStories = notificationOptions.IsNotifiedByStories,
                IsNotifiedByComments = notificationOptions.IsNotifiedByComments
            };
        }
    }
}
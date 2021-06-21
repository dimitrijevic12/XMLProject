using CSharpFunctionalExtensions;
using System;

namespace NotificationMicroservice.Core.Model
{
    public class NotificationOptions
    {
        public Guid Id { get; }
        public bool IsNotifiedByFollowRequests { get; }
        public bool IsNotifiedByMessages { get; }
        public bool IsNotifiedByPosts { get; }
        public bool IsNotifiedByStories { get; }
        public bool IsNotifiedByComments { get; }
        public RegisteredUser LoggedUser { get; }
        public RegisteredUser NotificationByUser { get; }

        private NotificationOptions(Guid id, bool isNotifiedByFollowRequests, bool isNotifiedByMessages,
            bool isNotifiedByPosts, bool isNotifiedByStories, bool isNotifiedByComments,
            RegisteredUser loggedUser, RegisteredUser notificationByUser)
        {
            Id = id;
            IsNotifiedByFollowRequests = isNotifiedByFollowRequests;
            IsNotifiedByMessages = isNotifiedByMessages;
            IsNotifiedByPosts = isNotifiedByPosts;
            IsNotifiedByStories = isNotifiedByStories;
            IsNotifiedByComments = isNotifiedByComments;
            LoggedUser = loggedUser;
            NotificationByUser = notificationByUser;
        }

        public static Result<NotificationOptions> Create(Guid id, bool isNotifiedByFollowRequests,
            bool isNotifiedByMessages, bool isNotifiedByPosts, bool isNotifiedByStories,
            bool isNotifiedByComments, RegisteredUser loggedUser, RegisteredUser notificationByUser)
        {
            return Result.Success(new NotificationOptions(id, isNotifiedByFollowRequests, isNotifiedByMessages, isNotifiedByPosts,
              isNotifiedByStories, isNotifiedByComments, loggedUser, notificationByUser));
        }
    }
}
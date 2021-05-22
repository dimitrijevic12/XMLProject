using CSharpFunctionalExtensions;
using System.Collections.Generic;

namespace NotificationMicroservice.Core.Model
{
    public class NotificationOptions : ValueObject
    {
        private readonly bool isNotifiedByFollowRequests;
        private readonly bool isNotifiedByMessages;
        private readonly bool isNotifiedByPosts;
        private readonly bool isNotifiedByStories;
        private readonly bool isNotifiedByComments;

        private NotificationOptions(bool isNotifiedByFollowRequests, bool isNotifiedByMessages,
            bool isNotifiedByPosts, bool isNotifiedByStories, bool isNotifiedByComments)
        {
            this.isNotifiedByFollowRequests = isNotifiedByFollowRequests;
            this.isNotifiedByMessages = isNotifiedByMessages;
            this.isNotifiedByPosts = isNotifiedByPosts;
            this.isNotifiedByStories = isNotifiedByStories;
            this.isNotifiedByComments = isNotifiedByComments;
        }

        public static Result<NotificationOptions> Create(bool isNotifiedByFollowRequests, bool isNotifiedByMessages, bool isNotifiedByPosts, bool isNotifiedByStories, bool isNotifiedByComments)
        {
            return Result.Success(new NotificationOptions(isNotifiedByFollowRequests, isNotifiedByMessages, isNotifiedByPosts,
              isNotifiedByStories, isNotifiedByComments));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return isNotifiedByFollowRequests;
            yield return isNotifiedByMessages;
            yield return isNotifiedByPosts;
            yield return isNotifiedByStories;
            yield return isNotifiedByComments;
        }
    }
}
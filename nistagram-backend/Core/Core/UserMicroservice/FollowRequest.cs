using CSharpFunctionalExtensions;
using System;

namespace Core.UserMicroservice
{
    public class FollowRequest
    {
        private readonly Guid id;
        private DateTime timestamp;
        private readonly RegisteredUser requestsFollow;
        private readonly RegisteredUser recievesFollow;

        protected FollowRequest(Guid id, DateTime timestamp, RegisteredUser requestsFollow, RegisteredUser recievesFollow)
        {
            this.id = id;
            this.timestamp = timestamp;
            this.requestsFollow = requestsFollow;
            this.requestsFollow = recievesFollow;
        }

        public static Result<FollowRequest> Create(Guid id, DateTime timestamp, RegisteredUser requestsFollow, RegisteredUser recievesFollow)
        {
            return Result.Success(new FollowRequest(id, timestamp, requestsFollow, recievesFollow));
        }
    }
}
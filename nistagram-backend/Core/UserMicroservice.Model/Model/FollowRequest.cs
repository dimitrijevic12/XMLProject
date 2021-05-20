using CSharpFunctionalExtensions;
using System;

namespace UserMicroservice.Core.Model
{
    public class FollowRequest
    {
        private readonly Guid id;
        private DateTime timestamp;
        private readonly RegisteredUser requestsFollow;
        private readonly RegisteredUser receivesFollow;

        protected FollowRequest(Guid id, DateTime timestamp, RegisteredUser requestsFollow, RegisteredUser receivesFollow)
        {
            this.id = id;
            this.timestamp = timestamp;
            this.requestsFollow = requestsFollow;
            this.receivesFollow = receivesFollow;
        }

        public static Result<FollowRequest> Create(Guid id, DateTime timestamp, RegisteredUser requestsFollow, RegisteredUser receivesFollow)
        {
            return Result.Success(new FollowRequest(id, timestamp, requestsFollow, receivesFollow));
        }
    }
}
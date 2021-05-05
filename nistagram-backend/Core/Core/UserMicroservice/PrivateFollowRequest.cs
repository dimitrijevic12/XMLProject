using CSharpFunctionalExtensions;
using System;

namespace Core.UserMicroservice
{
    public class PrivateFollowRequest : FollowRequest
    {
        private readonly bool approved;

        private PrivateFollowRequest(Guid id, DateTime timestamp, RegisteredUser requestsFollow, RegisteredUser receivesFollow, bool approved)
            : base(id, timestamp, requestsFollow, receivesFollow)
        {
            this.approved = approved;
        }

        public static Result<PrivateFollowRequest> Create(Guid id, DateTime timestamp, RegisteredUser requestsFollow,
            RegisteredUser receivesFollow, bool approved)
        {
            return Result.Success(new PrivateFollowRequest(id, timestamp, requestsFollow, receivesFollow, approved));
        }
    }
}
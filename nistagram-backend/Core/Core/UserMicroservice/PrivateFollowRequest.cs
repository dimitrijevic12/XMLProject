using CSharpFunctionalExtensions;
using System;

namespace Core.UserMicroservice
{
    public class PrivateFollowRequest : FollowRequest
    {
        private readonly bool approved;

        private PrivateFollowRequest(Guid id, DateTime timestamp, RegisteredUser requestsFollow, RegisteredUser recievesFollow, bool approved)
            : base(id, timestamp, requestsFollow, recievesFollow)
        {
            this.approved = approved;
        }

        public static Result<PrivateFollowRequest> Create(Guid id, DateTime timestamp, RegisteredUser requestsFollow,
            RegisteredUser recievesFollow, bool approved)
        {
            return Result.Success(new PrivateFollowRequest(id, timestamp, requestsFollow, recievesFollow, approved));
        }
    }
}
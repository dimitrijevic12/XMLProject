using CSharpFunctionalExtensions;
using System;

namespace NotificationMicroservice.Core.Model
{
    public class FollowRequest : Content
    {
        private FollowRequest(Guid id) : base(id)
        {
        }

        public static Result<FollowRequest> Create(Guid id)
        {
            return Result.Success(new FollowRequest(id));
        }
    }
}
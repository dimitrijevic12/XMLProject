using CSharpFunctionalExtensions;
using System;

namespace UserMicroservice.Core.Model
{
    public class AgentRequest
    {
        private readonly Guid id;
        private readonly bool isApproved;
        private readonly RegisteredUser registeredUser;

        private AgentRequest(Guid id, bool isApproved, RegisteredUser registeredUser)
        {
            this.id = id;
            this.isApproved = isApproved;
            this.registeredUser = registeredUser;
        }

        public static Result<AgentRequest> Create(Guid id, bool isApproved, RegisteredUser registeredUser)
        {
            return Result.Success(new AgentRequest(id, isApproved, registeredUser));
        }
    }
}
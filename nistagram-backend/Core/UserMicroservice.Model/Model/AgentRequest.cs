using CSharpFunctionalExtensions;
using System;

namespace UserMicroservice.Core.Model
{
    public class AgentRequest
    {
        public Guid Id { get; }
        public bool IsApproved { get; }
        public RegisteredUser RegisteredUser { get; }

        private AgentRequest(Guid id, bool isApproved, RegisteredUser registeredUser)
        {
            Id = id;
            IsApproved = isApproved;
            RegisteredUser = registeredUser;
        }

        public static Result<AgentRequest> Create(Guid id, bool isApproved, RegisteredUser registeredUser)
        {
            return Result.Success(new AgentRequest(id, isApproved, registeredUser));
        }
    }
}
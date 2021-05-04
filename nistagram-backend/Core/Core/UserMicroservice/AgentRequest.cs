using CSharpFunctionalExtensions;
using System;

namespace Core.UserMicroservice
{
    public class AgentRequest
    {
        private readonly Guid id;
        private readonly bool approved;

        private AgentRequest(Guid id, bool approved)
        {
            this.id = id;
            this.approved = approved;
        }

        public static Result<AgentRequest> Create(Guid id, bool approved)
        {
            return Result.Success(new AgentRequest(id, approved));
        }
    }
}
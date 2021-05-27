using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CampaignMicroservice.Core.Model
{
    public class VerifiedUser : RegisteredUser
    {
        private readonly Category category;

        private VerifiedUser(Guid id, Username username, FirstName firstName,
            LastName lastName, DateTime dateOfBirth, Gender gender, IEnumerable<Agent> blockedByAgents,
            IEnumerable<Agent> blockedAgents, IEnumerable<Agent> followsAgents, Category category)
            : base(id, username, firstName, lastName, dateOfBirth, gender, blockedByAgents, blockedAgents,
                  followsAgents)
        {
            this.category = category;
        }

        public static Result<VerifiedUser> Create(Guid id, Username username, FirstName firstName,
            LastName lastName, DateTime dateOfBirth, Gender gender, IEnumerable<Agent> blockedByAgents,
            IEnumerable<Agent> blockedAgents, IEnumerable<Agent> followsAgents, Category category)
        {
            return Result.Success(new VerifiedUser(id, username, firstName, lastName, dateOfBirth,
                gender, blockedByAgents, blockedAgents, followsAgents, category));
        }
    }
}
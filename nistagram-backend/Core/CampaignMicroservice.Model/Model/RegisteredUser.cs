using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CampaignMicroservice.Core.Model
{
    public class RegisteredUser
    {
        private Guid id;
        private readonly Username username;
        private readonly FirstName firstName;
        private readonly LastName lastName;
        private readonly DateTime dateOfBirth;
        private readonly Gender gender;
        private readonly IEnumerable<Agent> blockedByAgents;
        private readonly IEnumerable<Agent> blockedAgents;
        private readonly IEnumerable<Agent> followsAgents;

        protected RegisteredUser(Guid id, Username username, FirstName firstName,
            LastName lastName, DateTime dateOfBirth, Gender gender, IEnumerable<Agent> blockedByAgents,
            IEnumerable<Agent> blockedAgents, IEnumerable<Agent> followsAgents)
        {
            this.id = id;
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.blockedAgents = blockedAgents;
            this.blockedByAgents = blockedByAgents;
            this.followsAgents = followsAgents;
        }

        public static Result<RegisteredUser> Create(Guid id, Username username, FirstName firstName,
            LastName lastName, DateTime dateOfBirth, Gender gender, IEnumerable<Agent> blockedByAgents,
            IEnumerable<Agent> blockedAgents, IEnumerable<Agent> followsAgents)
        {
            return Result.Success(new RegisteredUser(id, username, firstName, lastName, dateOfBirth,
                gender, blockedByAgents, blockedAgents, followsAgents));
        }
    }
}
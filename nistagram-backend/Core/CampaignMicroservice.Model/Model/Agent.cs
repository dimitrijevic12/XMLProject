using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CampaignMicroservice.Core.Model
{
    public class Agent : RegisteredUser
    {
        private readonly WebsiteAddress websiteAddress;

        protected Agent(Guid id, Username username, FirstName firstName, LastName lastName, DateTime dateOfBirth, Gender gender,
            ProfileImagePath profileImagePath, bool isPrivate, IEnumerable<RegisteredUser> blockedByUsers, IEnumerable<RegisteredUser> blockedUsers,
            IEnumerable<RegisteredUser> following, IEnumerable<RegisteredUser> followers, IEnumerable<RegisteredUser> mutedByUsers,
            IEnumerable<RegisteredUser> mutedUsers, bool isBanned, WebsiteAddress websiteAddress)
            : base(id, username, firstName, lastName, dateOfBirth, gender, profileImagePath, isPrivate, blockedByUsers,
                                                        blockedUsers, following, followers, mutedByUsers, mutedUsers, isBanned)
        {
            this.websiteAddress = websiteAddress;
        }

        public static new Result<Agent> Create(Guid id, Username username, FirstName firstName, LastName lastName, DateTime dateOfBirth, Gender gender,
            ProfileImagePath profileImagePath, bool isPrivate, IEnumerable<RegisteredUser> blockedByUsers, IEnumerable<RegisteredUser> blockedUsers,
            IEnumerable<RegisteredUser> following, IEnumerable<RegisteredUser> followers, IEnumerable<RegisteredUser> mutedByUsers,
            IEnumerable<RegisteredUser> mutedUsers, bool isBanned, WebsiteAddress websiteAddress)
        {
            return Result.Success(new Agent(id, username, firstName, lastName, dateOfBirth, gender, profileImagePath, isPrivate, blockedByUsers,
                                            blockedUsers, following, followers, mutedByUsers, mutedUsers, isBanned, websiteAddress));
        }
    }
}
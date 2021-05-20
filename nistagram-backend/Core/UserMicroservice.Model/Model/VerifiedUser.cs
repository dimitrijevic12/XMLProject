using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace UserMicroservice.Core.Model
{
    public class VerifiedUser : RegisteredUser
    {
        private readonly Category category;

        private VerifiedUser(Guid id, Username username, EmailAddress emailAddress, FirstName firstName,
            LastName lastName, DateTime dateOfBirth, PhoneNumber phoneNumber,
            Gender gender, WebsiteAddress websiteAddress, Bio bio, bool isPrivate, bool isAcceptingMessages,
            bool isAcceptingTags, IEnumerable<RegisteredUser> blockedUsers, IEnumerable<RegisteredUser> blockedByUsers,
            IEnumerable<RegisteredUser> mutedUsers, IEnumerable<RegisteredUser> mutedByUsers,
            IEnumerable<RegisteredUser> following, IEnumerable<RegisteredUser> followers,
            IEnumerable<RegisteredUser> myCloseFriends, IEnumerable<RegisteredUser> closeFriendTo, Category category)
            : base(id, username, emailAddress, firstName, lastName, dateOfBirth, phoneNumber, gender, websiteAddress,
                  bio, isPrivate, isAcceptingMessages, isAcceptingTags, blockedUsers, blockedByUsers,
                  mutedUsers, mutedByUsers, following, followers, myCloseFriends, closeFriendTo)
        {
            this.category = category;
        }

        public static Result<VerifiedUser> Create(Guid id, Username username, EmailAddress emailAddress, FirstName firstName,
            LastName lastName, DateTime dateOfBirth, PhoneNumber phoneNumber,
            Gender gender, WebsiteAddress websiteAddress, Bio bio, bool isPrivate, bool isAcceptingMessages,
            bool isAcceptingTags, IEnumerable<RegisteredUser> blockedUsers, IEnumerable<RegisteredUser> blockedByUsers,
            IEnumerable<RegisteredUser> mutedUsers, IEnumerable<RegisteredUser> mutedByUsers,
            IEnumerable<RegisteredUser> following, IEnumerable<RegisteredUser> followers,
            IEnumerable<RegisteredUser> myCloseFriends, IEnumerable<RegisteredUser> closeFriendTo, Category category)
        {
            return Result.Success(new VerifiedUser(id, username, emailAddress, firstName,
            lastName, dateOfBirth, phoneNumber, gender, websiteAddress, bio, isPrivate, isAcceptingMessages,
            isAcceptingTags, blockedUsers, blockedByUsers,
            mutedUsers, mutedByUsers, following, followers, myCloseFriends, closeFriendTo, category));
        }
    }
}
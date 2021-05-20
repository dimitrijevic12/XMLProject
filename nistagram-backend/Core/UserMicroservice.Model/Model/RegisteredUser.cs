using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace UserMicroservice.Core.Model
{
    public class RegisteredUser : User
    {
        private readonly FirstName firstName;
        private readonly LastName lastName;
        private readonly DateTime dateOfBirth;
        private readonly PhoneNumber phoneNumber;
        private readonly Gender gender;
        private readonly WebsiteAddress websiteAddress;
        private readonly Bio bio;
        private readonly bool isPrivate;
        private readonly bool isAcceptingMessages;
        private readonly bool isAcceptingTags;
        private readonly IEnumerable<RegisteredUser> blockedUsers;
        private readonly IEnumerable<RegisteredUser> blockedByUsers;
        private readonly IEnumerable<RegisteredUser> mutedUsers;
        private readonly IEnumerable<RegisteredUser> mutedByUsers;
        private readonly IEnumerable<RegisteredUser> following;
        private readonly IEnumerable<RegisteredUser> followers;
        private readonly IEnumerable<RegisteredUser> myCloseFriends;
        private readonly IEnumerable<RegisteredUser> closeFriendTo;

        protected RegisteredUser(Guid id, Username username, EmailAddress emailAddress, FirstName firstName,
            LastName lastName, DateTime dateOfBirth, PhoneNumber phoneNumber,
            Gender gender, WebsiteAddress websiteAddress, Bio bio, bool isPrivate, bool isAcceptingMessages, bool isAcceptingTags,
            IEnumerable<RegisteredUser> blockedUsers, IEnumerable<RegisteredUser> blockedByUsers,
            IEnumerable<RegisteredUser> mutedUsers, IEnumerable<RegisteredUser> mutedByUsers,
            IEnumerable<RegisteredUser> following, IEnumerable<RegisteredUser> followers,
            IEnumerable<RegisteredUser> myCloseFriends, IEnumerable<RegisteredUser> closeFriendTo)
            : base(id, username, emailAddress)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.phoneNumber = phoneNumber;
            this.gender = gender;
            this.websiteAddress = websiteAddress;
            this.bio = bio;
            this.isPrivate = isPrivate;
            this.isAcceptingMessages = isAcceptingMessages;
            this.isAcceptingTags = isAcceptingTags;
            this.blockedUsers = blockedUsers;
            this.blockedByUsers = blockedByUsers;
            this.mutedUsers = mutedUsers;
            this.mutedByUsers = mutedByUsers;
            this.following = following;
            this.followers = followers;
            this.myCloseFriends = myCloseFriends;
            this.closeFriendTo = closeFriendTo;
        }

        public static Result<RegisteredUser> Create(Guid id, Username username, EmailAddress emailAddress, FirstName firstName,
            LastName lastName, DateTime dateOfBirth, PhoneNumber phoneNumber,
            Gender gender, WebsiteAddress websiteAddress, Bio bio, bool isPrivate, bool isAcceptingMessages, bool isAcceptingTags,
            IEnumerable<RegisteredUser> blockedUsers, IEnumerable<RegisteredUser> blockedByUsers,
            IEnumerable<RegisteredUser> mutedUsers, IEnumerable<RegisteredUser> mutedByUsers,
            IEnumerable<RegisteredUser> following, IEnumerable<RegisteredUser> followers,
            IEnumerable<RegisteredUser> myCloseFriends, IEnumerable<RegisteredUser> closeFriendTo)
        {
            return Result.Success(new RegisteredUser(id, username, emailAddress, firstName,
            lastName, dateOfBirth, phoneNumber,
            gender, websiteAddress, bio, isPrivate, isAcceptingMessages, isAcceptingTags,
            blockedUsers, blockedByUsers,
            mutedUsers, mutedByUsers,
            following, followers,
            myCloseFriends, closeFriendTo
            ));
        }
    }
}
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace UserMicroservice.Core.Model
{
    public class RegisteredUser : User
    {
        public FirstName FirstName { get; }
        public LastName LastName { get; }
        public DateTime DateOfBirth { get; }
        public PhoneNumber PhoneNumber { get; }
        public Gender Gender { get; }
        public WebsiteAddress WebsiteAddress { get; }
        public Bio Bio { get; }
        public Password Password { get; }
        public bool IsPrivate { get; }
        public bool IsAcceptingMessages { get; }
        public bool IsAcceptingTags { get; }
        public IEnumerable<RegisteredUser> BlockedUsers { get; }
        public IEnumerable<RegisteredUser> BlockedByUsers { get; }
        public IEnumerable<RegisteredUser> MutedUsers { get; }
        public IEnumerable<RegisteredUser> MutedByUsers { get; }
        public IEnumerable<RegisteredUser> Following { get; }
        public IEnumerable<RegisteredUser> Followers { get; }
        public IEnumerable<RegisteredUser> MyCloseFriends { get; }
        public IEnumerable<RegisteredUser> CloseFriendTo { get; }

        protected RegisteredUser(Guid id, Username username, EmailAddress emailAddress, FirstName firstName,
            LastName lastName, DateTime dateOfBirth, PhoneNumber phoneNumber,
            Gender gender, WebsiteAddress websiteAddress, Bio bio, bool isPrivate, bool isAcceptingMessages, bool isAcceptingTags,
            IEnumerable<RegisteredUser> blockedUsers, IEnumerable<RegisteredUser> blockedByUsers,
            IEnumerable<RegisteredUser> mutedUsers, IEnumerable<RegisteredUser> mutedByUsers,
            IEnumerable<RegisteredUser> following, IEnumerable<RegisteredUser> followers,
            IEnumerable<RegisteredUser> myCloseFriends, IEnumerable<RegisteredUser> closeFriendTo)
            : base(id, username, emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Gender = gender;
            WebsiteAddress = websiteAddress;
            Bio = bio;
            IsPrivate = isPrivate;
            IsAcceptingMessages = isAcceptingMessages;
            IsAcceptingTags = isAcceptingTags;
            BlockedUsers = blockedUsers;
            BlockedByUsers = blockedByUsers;
            MutedUsers = mutedUsers;
            MutedByUsers = mutedByUsers;
            Following = following;
            Followers = followers;
            MyCloseFriends = myCloseFriends;
            CloseFriendTo = closeFriendTo;
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
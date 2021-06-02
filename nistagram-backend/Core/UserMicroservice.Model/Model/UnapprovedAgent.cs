﻿using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMicroservice.Core.Model
{
    public class UnapprovedAgent : Agent
    {
        private UnapprovedAgent(Guid id, Username username, EmailAddress emailAddress, FirstName firstName,
            LastName lastName, DateTime dateOfBirth, PhoneNumber phoneNumber,
            Gender gender, WebsiteAddress websiteAddress, Bio bio, bool isPrivate, bool isAcceptingMessages, bool isAcceptingTags, Password password,
            IEnumerable<RegisteredUser> blockedUsers, IEnumerable<RegisteredUser> blockedByUsers,
            IEnumerable<RegisteredUser> mutedUsers, IEnumerable<RegisteredUser> mutedByUsers,
            IEnumerable<RegisteredUser> following, IEnumerable<RegisteredUser> followers,
            IEnumerable<RegisteredUser> myCloseFriends, IEnumerable<RegisteredUser> closeFriendTo)
            : base(id, username, emailAddress, firstName,
                   lastName, dateOfBirth, phoneNumber,
                   gender, websiteAddress, bio, isPrivate, isAcceptingMessages, isAcceptingTags, password,
                   blockedUsers, blockedByUsers,
                   mutedUsers, mutedByUsers,
                   following, followers,
                   myCloseFriends, closeFriendTo)
        {
        }

        public static new Result<UnapprovedAgent> Create(Guid id, Username username, EmailAddress emailAddress, FirstName firstName,
            LastName lastName, DateTime dateOfBirth, PhoneNumber phoneNumber,
            Gender gender, WebsiteAddress websiteAddress, Bio bio, bool isPrivate, bool isAcceptingMessages, bool isAcceptingTags, Password password,
            IEnumerable<RegisteredUser> blockedUsers, IEnumerable<RegisteredUser> blockedByUsers,
            IEnumerable<RegisteredUser> mutedUsers, IEnumerable<RegisteredUser> mutedByUsers,
            IEnumerable<RegisteredUser> following, IEnumerable<RegisteredUser> followers,
            IEnumerable<RegisteredUser> myCloseFriends, IEnumerable<RegisteredUser> closeFriendTo)
        {
            return Result.Success(new UnapprovedAgent(id, username, emailAddress, firstName,
            lastName, dateOfBirth, phoneNumber,
            gender, websiteAddress, bio, isPrivate, isAcceptingMessages, isAcceptingTags, password,
            blockedUsers, blockedByUsers,
            mutedUsers, mutedByUsers,
            following, followers,
            myCloseFriends, closeFriendTo));
        }
    }
}
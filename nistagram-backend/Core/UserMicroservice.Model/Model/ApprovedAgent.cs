﻿using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMicroservice.Core.Model
{
    public class ApprovedAgent : Agent
    {
        private ApprovedAgent(Guid id, Username username, EmailAddress emailAddress, FirstName firstName,
            LastName lastName, DateTime dateOfBirth, PhoneNumber phoneNumber,
            Gender gender, WebsiteAddress websiteAddress, Bio bio, bool isPrivate, bool isAcceptingMessages, bool isAcceptingTags, Password password,
            ProfileImagePath profileImagePath, IEnumerable<RegisteredUser> blockedUsers, IEnumerable<RegisteredUser> blockedByUsers,
            IEnumerable<RegisteredUser> mutedUsers, IEnumerable<RegisteredUser> mutedByUsers,
            IEnumerable<RegisteredUser> following, IEnumerable<RegisteredUser> followers,
            IEnumerable<RegisteredUser> myCloseFriends, IEnumerable<RegisteredUser> closeFriendTo)
            : base(id, username, emailAddress, firstName,
                   lastName, dateOfBirth, phoneNumber,
                   gender, websiteAddress, bio, isPrivate, isAcceptingMessages, isAcceptingTags, password,
                   profileImagePath, blockedUsers, blockedByUsers,
                   mutedUsers, mutedByUsers,
                   following, followers,
                   myCloseFriends, closeFriendTo)
        {
        }

        public static new Result<ApprovedAgent> Create(Guid id, Username username, EmailAddress emailAddress, FirstName firstName,
            LastName lastName, DateTime dateOfBirth, PhoneNumber phoneNumber,
            Gender gender, WebsiteAddress websiteAddress, Bio bio, bool isPrivate, bool isAcceptingMessages, bool isAcceptingTags, Password password,
            ProfileImagePath profileImagePath, IEnumerable<RegisteredUser> blockedUsers, IEnumerable<RegisteredUser> blockedByUsers,
            IEnumerable<RegisteredUser> mutedUsers, IEnumerable<RegisteredUser> mutedByUsers,
            IEnumerable<RegisteredUser> following, IEnumerable<RegisteredUser> followers,
            IEnumerable<RegisteredUser> myCloseFriends, IEnumerable<RegisteredUser> closeFriendTo)
        {
            return Result.Success(new ApprovedAgent(id, username, emailAddress, firstName,
            lastName, dateOfBirth, phoneNumber,
            gender, websiteAddress, bio, isPrivate, isAcceptingMessages, isAcceptingTags, password,
            profileImagePath, blockedUsers, blockedByUsers,
            mutedUsers, mutedByUsers,
            following, followers,
            myCloseFriends, closeFriendTo));
        }
    }
}
﻿using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace StoryMicroservice.Core.Model
{
    public class CloseFriendStory : Story
    {
        private CloseFriendStory(Guid id, ContentPath contentPath, DateTime timeStamp, Duration duration, Description description,
            RegisteredUser registeredUser, Location location,
            IEnumerable<RegisteredUser> seenByUsers, IEnumerable<RegisteredUser> taggedUsers, IEnumerable<HashTag> hashTags)
            : base(id, contentPath, timeStamp, duration, description, registeredUser, location,
                seenByUsers, taggedUsers, hashTags)
        {
        }

        public static new Result<CloseFriendStory> Create(Guid id, ContentPath contentPath, DateTime timeStamp, Duration duration, Description description,
            RegisteredUser registeredUser, Location location,
            IEnumerable<RegisteredUser> seenByUsers, IEnumerable<RegisteredUser> taggedUsers, IEnumerable<HashTag> hashTags)
        {
            return Result.Success(new CloseFriendStory(id, contentPath, timeStamp, duration, description, registeredUser, location,

                seenByUsers, taggedUsers, hashTags));
        }
    }
}
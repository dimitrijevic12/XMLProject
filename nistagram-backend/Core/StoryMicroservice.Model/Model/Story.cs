using CSharpFunctionalExtensions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace StoryMicroservice.Core.Model
{
    public class Story
    {
        public Guid Id { get; }
        public ContentPath ContentPath { get; }
        public DateTime TimeStamp { get; }
        public Duration Duration { get; }
        public Description Description { get; }
        public RegisteredUser RegisteredUser { get; }
        public Location Location { get; }
        public IEnumerable<RegisteredUser> TaggedUsers { get; }
        public IEnumerable<HashTag> HashTags { get; }

        public Story(Guid id, ContentPath contentPath, DateTime timeStamp, Duration duration, Description description,
            RegisteredUser registeredUser, Location location, IEnumerable<RegisteredUser> taggedUsers, IEnumerable<HashTag> hashTags)
        {
            Id = id;
            ContentPath = contentPath;
            TimeStamp = timeStamp;
            Duration = duration;
            Description = description;
            RegisteredUser = registeredUser;
            Location = location;
            TaggedUsers = taggedUsers;
            HashTags = hashTags;
        }

        public static Result<Story> Create(Guid id, ContentPath contentPath, DateTime timeStamp, Duration duration, Description description,
            RegisteredUser registeredUser, Location location, IEnumerable<RegisteredUser> taggedUsers, IEnumerable<HashTag> hashTags)
        {
            return Result.Success(new Story(id, contentPath, timeStamp, duration, description, registeredUser, location, taggedUsers, hashTags));
        }
    }
}
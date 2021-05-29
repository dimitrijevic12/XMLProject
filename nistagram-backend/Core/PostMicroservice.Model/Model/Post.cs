using System;
using System.Collections.Generic;

namespace PostMicroservice.Core.Model
{
    public abstract class Post
    {
        public Guid Id { get; }
        public DateTime TimeStamp { get; }
        public Description Description { get; }
        public RegisteredUser RegisteredUser { get; }
        public IEnumerable<RegisteredUser> Likes { get; }
        public IEnumerable<RegisteredUser> Dislikes { get; }
        public IEnumerable<Comment> Comments { get; }
        public Location Location { get; }
        public IEnumerable<RegisteredUser> TaggedUsers { get; }
        public IEnumerable<HashTag> HashTags { get; }

        protected Post(Guid id, DateTime timeStamp, Description description,
            RegisteredUser registeredUser, IEnumerable<RegisteredUser> likes,
            IEnumerable<RegisteredUser> dislikes, IEnumerable<Comment> comments, Location location,
            IEnumerable<RegisteredUser> taggedUsers, IEnumerable<HashTag> hashTags)
        {
            Id = id;
            TimeStamp = timeStamp;
            Description = description;
            RegisteredUser = registeredUser;
            Likes = likes;
            Dislikes = dislikes;
            Comments = comments;
            Location = location;
            TaggedUsers = taggedUsers;
            HashTags = hashTags;
        }
    }
}
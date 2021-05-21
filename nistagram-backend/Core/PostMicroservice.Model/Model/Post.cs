using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace PostMicroservice.Core.Model
{
    public abstract class Post
    {
        private Guid id;
        private readonly DateTime timeStamp;
        private readonly Description description;
        private readonly RegisteredUser registeredUser;
        private readonly IEnumerable<RegisteredUser> likes;
        private readonly IEnumerable<RegisteredUser> dislikes;
        private readonly IEnumerable<Comment> comments;
        private readonly Location location;

        protected Post(Guid id, DateTime timeStamp, Description description,
            RegisteredUser registeredUser, IEnumerable<RegisteredUser> likes,
            IEnumerable<RegisteredUser> dislikes, IEnumerable<Comment> comments, Location location)
        {
            this.id = id;
            this.timeStamp = timeStamp;
            this.description = description;
            this.registeredUser = registeredUser;
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = comments;
            this.location = location;
        }
    }
}
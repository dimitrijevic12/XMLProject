using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace PostMicroservice.Core.Model
{
    public class Post
    {
        private Guid id;
        private readonly ContentPath contentPath;
        private readonly DateTime timeStamp;
        private readonly Description description;
        private readonly RegisteredUser registeredUser;
        private readonly IEnumerable<RegisteredUser> likes;
        private readonly IEnumerable<RegisteredUser> dislikes;
        private readonly IEnumerable<Comment> comments;
        private readonly Location location;

        private Post(Guid id, ContentPath contentPath, DateTime timeStamp, Description description,
            RegisteredUser registeredUser, IEnumerable<RegisteredUser> likes,
            IEnumerable<RegisteredUser> dislikes, IEnumerable<Comment> comments, Location location)
        {
            this.id = id;
            this.contentPath = contentPath;
            this.timeStamp = timeStamp;
            this.description = description;
            this.registeredUser = registeredUser;
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = comments;
            this.location = location;
        }

        public static Result<Post> Create(Guid id, ContentPath contentPath, DateTime timeStamp, Description description,
            RegisteredUser registeredUser, IEnumerable<RegisteredUser> likes,
            IEnumerable<RegisteredUser> dislikes, IEnumerable<Comment> comments, Location location)
        {
            return Result.Success(new Post(id, contentPath, timeStamp, description,
                    registeredUser, likes, dislikes, comments, location));
        }
    }
}
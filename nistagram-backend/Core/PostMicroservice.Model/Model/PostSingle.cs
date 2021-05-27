using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace PostMicroservice.Core.Model
{
    public class PostSingle : Post
    {
        private readonly ContentPath contentPath;

        private PostSingle(Guid id, DateTime timeStamp, Description description,
            RegisteredUser registeredUser, IEnumerable<RegisteredUser> likes,
            IEnumerable<RegisteredUser> dislikes, IEnumerable<Comment> comments,
            Location location, IEnumerable<RegisteredUser> taggedUsers, IEnumerable<HashTag> hashTags, ContentPath contentPath)
            : base(id, timeStamp, description, registeredUser, likes, dislikes, comments, location, taggedUsers, hashTags)
        {
            this.contentPath = contentPath;
        }

        public static Result<PostSingle> Create(Guid id, DateTime timeStamp, Description description,
            RegisteredUser registeredUser, IEnumerable<RegisteredUser> likes,
            IEnumerable<RegisteredUser> dislikes, IEnumerable<Comment> comments,
            Location location, IEnumerable<RegisteredUser> taggedUsers, IEnumerable<HashTag> hashTags, ContentPath contentPath)
        {
            return Result.Success(new PostSingle(id, timeStamp, description,
                                registeredUser, likes, dislikes, comments, location, taggedUsers, hashTags, contentPath));
        }
    }
}
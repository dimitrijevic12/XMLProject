using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace PostMicroservice.Core.Model
{
    public class Comment
    {
        private readonly Guid id;
        private readonly DateTime timeStamp;
        private readonly CommentText commentText;
        private readonly RegisteredUser registeredUser;
        private readonly IEnumerable<RegisteredUser> taggedUsers;

        private Comment(Guid id, DateTime timeStamp, CommentText commentText, RegisteredUser registeredUser, IEnumerable<RegisteredUser> taggedUsers)
        {
            this.id = id;
            this.timeStamp = timeStamp;
            this.commentText = commentText;
            this.registeredUser = registeredUser;
            this.taggedUsers = taggedUsers;
        }

        public static Result<Comment> Create(Guid id, DateTime timeStamp, CommentText commentText, RegisteredUser registeredUser, IEnumerable<RegisteredUser> taggedUsers)
        {
            return Result.Success(new Comment(id, timeStamp, commentText, registeredUser, taggedUsers));
        }
    }
}
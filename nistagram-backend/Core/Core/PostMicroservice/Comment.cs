using CSharpFunctionalExtensions;
using System;

namespace Core.PostMicroservice
{
    public class Comment
    {
        private readonly Guid id;
        private readonly DateTime timeStamp;
        private readonly CommentText commentText;
        private readonly RegisteredUser registeredUser;

        private Comment(Guid id, DateTime timeStamp, CommentText commentText, RegisteredUser registeredUser)
        {
            this.id = id;
            this.timeStamp = timeStamp;
            this.commentText = commentText;
            this.registeredUser = registeredUser;
        }

        public static Result<Comment> Create(Guid id, DateTime timeStamp, CommentText commentText, RegisteredUser registeredUser)
        {
            return Result.Success(new Comment(id, timeStamp, commentText, registeredUser));
        }
    }
}
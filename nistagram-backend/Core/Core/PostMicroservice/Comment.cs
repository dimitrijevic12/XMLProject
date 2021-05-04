using CSharpFunctionalExtensions;
using System;

namespace Core.PostMicroservice
{
    public class Comment
    {
        private readonly Guid id;
        private readonly DateTime timeStamp;
        private RegisteredUser registeredUser;

        private Comment(Guid id, DateTime timeStamp, RegisteredUser registeredUser)
        {
            this.id = id;
            this.timeStamp = timeStamp;
            this.registeredUser = registeredUser;
        }

        public static Result<Comment> Create(Guid id, DateTime timeStamp, RegisteredUser registeredUser)
        {
            return Result.Success(new Comment(id, timeStamp, registeredUser));
        }
    }
}
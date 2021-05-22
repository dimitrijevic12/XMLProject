using CSharpFunctionalExtensions;
using System;

namespace NotificationService.Core.Model
{
    public class Comment : Content
    {
        private Comment(Guid id) : base(id)
        {
        }

        public static Result<Comment> Create(Guid id)
        {
            return Result.Success(new Comment(id));
        }
    }
}
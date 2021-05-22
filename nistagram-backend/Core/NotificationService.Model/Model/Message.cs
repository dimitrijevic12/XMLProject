using CSharpFunctionalExtensions;
using System;

namespace NotificationService.Core.Model
{
    public class Message : Content
    {
        private Message(Guid id) : base(id)
        {
        }

        public static Result<Message> Create(Guid id)
        {
            return Result.Success(new Message(id));
        }
    }
}
using CSharpFunctionalExtensions;
using System;

namespace NotificationMicroservice.Core.Model
{
    public class Notification
    {
        public Guid Id { get; }
        public DateTime TimeStamp { get; }
        public Content Content { get; }
        public RegisteredUser RegisteredUser { get; }

        private Notification(Guid id, DateTime timestamp, Content content, RegisteredUser registeredUser)
        {
            Id = id;
            TimeStamp = timestamp;
            Content = content;
            RegisteredUser = registeredUser;
        }

        public static Result<Notification> Create(Guid id, DateTime timestamp, Content content, RegisteredUser registeredUser)
        {
            return Result.Success(new Notification(id, timestamp, content, registeredUser));
        }
    }
}
using CSharpFunctionalExtensions;
using System;

namespace NotificationMicroservice.Core.Model
{
    public class Notification
    {
        private readonly Guid id;
        private readonly DateTime timestamp;

        private Notification(Guid id, DateTime timestamp)
        {
            this.id = id;
            this.timestamp = timestamp;
        }

        public static Result<Notification> Create(Guid id, DateTime timestamp)
        {
            return Result.Success(new Notification(id, timestamp));
        }
    }
}
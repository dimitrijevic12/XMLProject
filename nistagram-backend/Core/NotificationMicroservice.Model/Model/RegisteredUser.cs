using CSharpFunctionalExtensions;
using System;

namespace NotificationMicroservice.Core.Model
{
    public class RegisteredUser
    {
        private readonly Guid id;
        private readonly Username username;
        private readonly NotificationOptions notificationOptions;

        private RegisteredUser(Guid id, Username username, NotificationOptions notificationOptions)
        {
            this.id = id;
            this.username = username;
            this.notificationOptions = notificationOptions;
        }

        public static Result<RegisteredUser> Create(Guid id, Username username, NotificationOptions notificationOptions)
        {
            return Result.Success(new RegisteredUser(id, username, notificationOptions));
        }
    }
}
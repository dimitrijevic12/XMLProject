using CSharpFunctionalExtensions;
using System;

namespace NotificationMicroservice.Core.Model
{
    public class RegisteredUser
    {
        public Guid Id { get; }
        public Username Username { get; }
        public NotificationOptions NotificationOptions { get; }
        public ProfilePicturePath ProfilePicturePath { get; }

        private RegisteredUser(Guid id, Username username, NotificationOptions notificationOptions,
            ProfilePicturePath profilePicturePath)
        {
            Id = id;
            Username = username;
            NotificationOptions = notificationOptions;
            ProfilePicturePath = profilePicturePath;
        }

        public static Result<RegisteredUser> Create(Guid id, Username username,
            NotificationOptions notificationOptions, ProfilePicturePath profilePicturePath)
        {
            return Result.Success(new RegisteredUser(id, username, notificationOptions, profilePicturePath));
        }
    }
}
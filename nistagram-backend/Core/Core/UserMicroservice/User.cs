using System;

namespace Core.UserMicroservice
{
    public abstract class User
    {
        public Guid Id { get; }
        public Username Username { get; }
        public EmailAddress EmailAddress { get; }

        public User(Guid id, Username username, EmailAddress emailAddress)
        {
            Id = id;
            Username = username;
            EmailAddress = emailAddress;
        }
    }
}
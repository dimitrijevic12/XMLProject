using CSharpFunctionalExtensions;
using System;

namespace StoryMicroservice.Core.Model
{
    public class RegisteredUser
    {
        public Guid Id { get; }
        public Username Username { get; }
        public FirstName FirstName { get; }
        public LastName LastName { get; }
        public bool IsPrivate { get; }
        public bool IsAcceptingTags { get; }

        public RegisteredUser(Guid id, Username username, FirstName firstname, LastName lastname, bool isPrivate, bool isAcceptingTags)
        {
            Id = id;
            Username = username;
            FirstName = firstname;
            LastName = lastname;
            IsPrivate = isPrivate;
            IsAcceptingTags = isAcceptingTags;
        }

        public static Result<RegisteredUser> Create(Guid id, Username username, FirstName firstname,
            LastName lastname, bool isPrivate, bool isAcceptingTags)
        {
            return Result.Success(new RegisteredUser(id, username, firstname,
            lastname, isPrivate, isAcceptingTags));
        }
    }
}
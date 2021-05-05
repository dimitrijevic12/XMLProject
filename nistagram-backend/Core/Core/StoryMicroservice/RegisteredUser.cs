using CSharpFunctionalExtensions;
using System;

namespace Core.StoryMicroservice
{
    public class RegisteredUser
    {
        public Guid id;
        public Username username;
        private readonly FirstName firstName;
        private readonly LastName lastName;
        private readonly bool isPrivate;
        private readonly bool isAcceptingTags;

        public RegisteredUser(Guid id, Username username, FirstName firstName, LastName lastName, bool isPrivate, bool isAcceptingTags)
        {
            this.id = id;
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.isPrivate = isPrivate;
            this.isAcceptingTags = isAcceptingTags;
        }

        public static Result<RegisteredUser> Create(Guid id, Username username, FirstName firstName,
           LastName lastName, bool isPrivate, bool isAcceptingTags)
        {
            return Result.Success(new RegisteredUser(id, username, firstName,
            lastName, isPrivate, isAcceptingTags));
        }
    }
}
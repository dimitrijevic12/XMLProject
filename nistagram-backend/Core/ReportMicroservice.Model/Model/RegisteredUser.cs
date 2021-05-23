using CSharpFunctionalExtensions;
using System;

namespace ReportMicroservice.Core.Model
{
    public class RegisteredUser
    {
        private readonly Guid id;
        private readonly Username username;

        private RegisteredUser(Guid id, Username username)
        {
            this.id = id;
            this.username = username;
        }

        public static Result<RegisteredUser> Create(Guid id, Username username)
        {
            return Result.Success(new RegisteredUser(id, username));
        }
    }
}
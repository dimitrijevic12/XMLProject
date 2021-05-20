using CSharpFunctionalExtensions;
using System;

namespace UserMicroservice.Core.Model
{
    public class Admin : User
    {
        private Admin(Guid id, Username username, EmailAddress emailAddress) : base(id, username, emailAddress)
        {
        }

        public static Result<Admin> Create(Guid id, Username username, EmailAddress emailAddress)
        {
            return Result.Success(new Admin(id, username, emailAddress));
        }
    }
}
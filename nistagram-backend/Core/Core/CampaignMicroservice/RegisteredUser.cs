using CSharpFunctionalExtensions;
using System;

namespace Core.CampaignMicroservice
{
    public class RegisteredUser
    {
        private Guid id;
        private readonly Username username;
        private readonly FirstName firstName;
        private readonly LastName lastName;
        private readonly DateTime dateOfBirth;
        private readonly Gender gender;

        private RegisteredUser(Guid id, Username username, FirstName firstName,
            LastName lastName, DateTime dateOfBirth, Gender gender)
        {
            this.id = id;
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
        }

        public static Result<RegisteredUser> Create(Guid id, Username username, FirstName firstName,
            LastName lastName, DateTime dateOfBirth, Gender gender)
        {
            return Result.Success(new RegisteredUser(id, username, firstName,
            lastName, dateOfBirth, gender));
        }
    }
}
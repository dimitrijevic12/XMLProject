using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace Core.CampaignMicroservice
{
    public class TargetAudience
    {
        private readonly DateTime minDateOfBirth;
        private readonly DateTime maxDateOfBirth;
        private readonly Gender gender;
        private List<RegisteredUser> audience;

        private TargetAudience(DateTime minDateOfBirth, DateTime maxDateOfBirth, Gender gender,
            List<RegisteredUser> audience)
        {
            this.minDateOfBirth = minDateOfBirth;
            this.maxDateOfBirth = maxDateOfBirth;
            this.gender = gender;
            this.audience = audience;
        }

        public static Result<TargetAudience> Create(DateTime minDateOfBirth, DateTime maxDateOfBirth,
            Gender gender, List<RegisteredUser> audience)
        {
            return Result.Success(new TargetAudience(minDateOfBirth, maxDateOfBirth, gender, audience));
        }
    }
}
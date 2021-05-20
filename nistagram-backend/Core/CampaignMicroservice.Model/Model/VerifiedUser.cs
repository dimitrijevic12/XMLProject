using CSharpFunctionalExtensions;
using System;

namespace CampaignMicroservice.Core.Model
{
    public class VerifiedUser
    {
        private readonly Guid id;
        private readonly Category category;

        private VerifiedUser(Guid id, Category category)
        {
            this.id = id;
            this.category = category;
        }

        public static Result<VerifiedUser> Create(Guid id, Category category)
        {
            return Result.Success(new VerifiedUser(id, category));
        }
    }
}
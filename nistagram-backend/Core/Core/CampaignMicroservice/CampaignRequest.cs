using CSharpFunctionalExtensions;
using System;

namespace Core.CampaignMicroservice
{
    public class CampaignRequest
    {
        private readonly Guid id;
        private readonly bool approved;
        private readonly Campaign campaign;
        private readonly VerifiedUser verifiedUser;

        private CampaignRequest(Guid id, bool approved, Campaign campaign, VerifiedUser verifiedUser)
        {
            this.id = id;
            this.approved = approved;
            this.campaign = campaign;
            this.verifiedUser = verifiedUser;
        }

        public static Result<CampaignRequest> Create(Guid id, bool approved, Campaign campaign,
            VerifiedUser verifiedUser)
        {
            return Result.Success(new CampaignRequest(id, approved, campaign, verifiedUser));
        }
    }
}
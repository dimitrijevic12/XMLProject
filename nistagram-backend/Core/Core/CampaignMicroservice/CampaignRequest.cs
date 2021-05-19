using CSharpFunctionalExtensions;
using System;

namespace Core.CampaignMicroservice
{
    public class CampaignRequest
    {
        private readonly Guid id;
        private readonly bool isApproved;
        private readonly Campaign campaign;
        private readonly VerifiedUser verifiedUser;

        private CampaignRequest(Guid id, bool isApproved, Campaign campaign, VerifiedUser verifiedUser)
        {
            this.id = id;
            this.isApproved = isApproved;
            this.campaign = campaign;
            this.verifiedUser = verifiedUser;
        }

        public static Result<CampaignRequest> Create(Guid id, bool isApproved, Campaign campaign,
            VerifiedUser verifiedUser)
        {
            return Result.Success(new CampaignRequest(id, isApproved, campaign, verifiedUser));
        }
    }
}
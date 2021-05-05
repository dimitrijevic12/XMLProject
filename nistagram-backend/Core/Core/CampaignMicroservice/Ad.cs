using CSharpFunctionalExtensions;
using System;

namespace Core.CampaignMicroservice
{
    public class Ad
    {
        private readonly Guid id;
        private readonly ContentPath contentPath;
        private readonly Link link;
        private readonly ClickCount clickCount;
        private readonly Campaign campaign;
        private readonly VerifiedUser verifiedUser;

        private Ad(Guid id, ContentPath contentPath, Link link, ClickCount clickCount,
            Campaign campaign, VerifiedUser verifiedUser)
        {
            this.id = id;
            this.contentPath = contentPath;
            this.link = link;
            this.clickCount = clickCount;
            this.campaign = campaign;
            this.verifiedUser = verifiedUser;
        }

        public static Result<Ad> Create(Guid id, ContentPath contentPath, Link link, ClickCount clickCount,
            Campaign campaign, VerifiedUser verifiedUser)
        {
            return Result.Success(new Ad(id, contentPath, link, clickCount, campaign, verifiedUser));
        }
    }
}
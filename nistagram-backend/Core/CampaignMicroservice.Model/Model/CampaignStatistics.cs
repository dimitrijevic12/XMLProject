using CSharpFunctionalExtensions;

namespace CampaignMicroservice.Core.Model
{
    public class CampaignStatistics
    {
        private readonly LikesCount likesCount;
        private readonly DislikesCount dislikesCount;
        private readonly ExposureCount exposureCount;
        private readonly ClickCount clickCount;

        private CampaignStatistics(LikesCount likesCount, DislikesCount dislikesCount,
            ExposureCount exposureCount, ClickCount clickCount)
        {
            this.likesCount = likesCount;
            this.dislikesCount = dislikesCount;
            this.exposureCount = exposureCount;
            this.clickCount = clickCount;
        }

        public static Result<CampaignStatistics> Create(LikesCount likesCount, DislikesCount dislikesCount,
            ExposureCount exposureCount, ClickCount clickCount)
        {
            return Result.Success(new CampaignStatistics(likesCount, dislikesCount,
            exposureCount, clickCount));
        }
    }
}
using CampaignMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace CampaignService.DataAccess.Adaptee
{
    public class AdAdaptee
    {
        /*public Ad ConvertSqlDataReaderToAd(DataRow dataRow)
        {
            return Ad.Create(
                    id: Guid.Parse(dataRow[0].ToString().Trim()),
                    contentPath: ContentPath.Create(dataRow[1].ToString().Trim()).Value,
                    link: Link.Create(dataRow[2].ToString().Trim()).Value,
                    clickCount: ClickCount.Create(int.Parse(dataRow[3].ToString().Trim())).Value,
                    campaign: Campaign.Create(
                        id: Guid.Parse(dataRow[0].ToString().Trim()),
                        targetAudience: TargetAudience.Create(
                            minDateOfBirth: DateTime.Parse(dataRow[1].ToString().Trim()),
                            maxDateOfBirth: DateTime.Parse(dataRow[2].ToString().Trim()),
                            gender: Gender.Create(dataRow[3].ToString().Trim()).Value,
                            audience: new List<RegisteredUser>()).Value,
                        agent: Agent.Create(id: Guid.Parse(dataRow[4].ToString().Trim())).Value,
                        campaignStatistics: CampaignStatistics.Create(
                            likesCount: LikesCount.Create(int.Parse(dataRow[5].ToString().Trim())).Value,
                            dislikesCount: DislikesCount.Create(int.Parse(dataRow[6].ToString().Trim())).Value,
                            exposureCount: ExposureCount.Create(int.Parse(dataRow[7].ToString().Trim())).Value,
                            clickCount: ClickCount.Create(int.Parse(dataRow[8].ToString().Trim())).Value).Value).Value,
                    verifiedUser: VerifiedUser.Create(
                        id: Guid.Parse(dataRow[9].ToString().Trim()),
                        category: Category.Create(dataRow[10].ToString().Trim()).Value).Value).Value;
        }*/
    }
}
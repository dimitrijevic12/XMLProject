using CampaignMicroservice.Core.Interface;
using CampaignMicroservice.Core.Model;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignService.DataAccess.Implementation
{
    public class CampaignRepository : Repository, ICampaignRepository
    {
        public CampaignRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Maybe<Campaign> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Campaign campaign)
        {
            StringBuilder queryBuilder = new StringBuilder("INSERT INTO dbo.Campaign ");
            queryBuilder.Append("(id, agent_id, likes_count, dislikes_count, exposure_count, click_count, type, min_date_of_birth, max_date_of_birth, gender, start_date, end_date, date_of_change) ");
            queryBuilder.Append("VALUES (@Id, @Agent_id, @Likes_count, @Dislikes_count, @Exposure_count, @Click_count, @Type, @MinDateOfBirth, @MaxDateOfBirth, @Gender, @Start_date, @End_date, @Date_of_change);");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = campaign.Id },
                 new SqlParameter("@Agent_id", SqlDbType.UniqueIdentifier) { Value = campaign.Agent.Id },
                 new SqlParameter("@Likes_count", SqlDbType.Int) { Value = int.Parse(campaign.CampaignStatistics.LikesCount.ToString()) },
                 new SqlParameter("@Dislikes_count", SqlDbType.Int) { Value = int.Parse(campaign.CampaignStatistics.DislikesCount.ToString()) },
                 new SqlParameter("@Exposure_count", SqlDbType.Int) { Value = int.Parse(campaign.CampaignStatistics.ExposureCount.ToString()) },
                 new SqlParameter("@Click_count", SqlDbType.Int) { Value = int.Parse(campaign.CampaignStatistics.ClickCount.ToString()) },
                 new SqlParameter("@Type", SqlDbType.NVarChar) { Value = campaign.GetType().Name },
                 new SqlParameter("@MinDateOfBirth", SqlDbType.NVarChar) { Value = campaign.TargetAudience.MinDateOfBirth },
                 new SqlParameter("@MaxDateOfBirth", SqlDbType.NVarChar) { Value = campaign.TargetAudience.MaxDateOfBirth},
                 new SqlParameter("@Gender", SqlDbType.NVarChar) { Value = campaign.TargetAudience.Gender},
             };
            if (campaign.GetType().Name.Equals("RecurringPostCampaign"))
            {
                RecurringPostCampaign recurringPostCampaign = (RecurringPostCampaign)campaign;
                parameters.Add(new SqlParameter("@Start_date", SqlDbType.DateTime) { Value = recurringPostCampaign.StartDate });
                parameters.Add(new SqlParameter("@End_date", SqlDbType.DateTime) { Value = recurringPostCampaign.EndDate });
            }
            else
            {
                RecurringStoryCampaign recurringStoryCampaign = (RecurringStoryCampaign)campaign;
                parameters.Add(new SqlParameter("@Start_date", SqlDbType.DateTime) { Value = recurringStoryCampaign.StartDate });
                parameters.Add(new SqlParameter("@End_date", SqlDbType.DateTime) { Value = recurringStoryCampaign.EndDate });
            }

            ExecuteQuery(query, parameters);
        }

        public void Update(Campaign campaign)
        {
            throw new NotImplementedException();
        }
    }
}
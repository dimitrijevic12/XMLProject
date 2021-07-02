using CampaignMicroservice.Core.Interface;
using CampaignMicroservice.Core.Model;
using CampaignService.DataAccess.Adaptee;
using CampaignService.DataAccess.Adapter;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CampaignService.DataAccess.Implementation
{
    public class CampaignRepository : Repository, ICampaignRepository
    {
        public CampaignAdapter _campaignTarget = new CampaignAdapter(new CampaignAdaptee());
        public IUserRepository _userRepository;

        public CampaignRepository(IConfiguration configuration, IUserRepository userRepository) :
            base(configuration)
        {
            _userRepository = userRepository;
        }

        public Maybe<Campaign> GetById(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT c.id, t.min_date_of_birth, " +
                "t.max_date_of_birth, t.gender, c.agent_id, a.username, a.first_name, a.last_name, " +
                "a.date_of_birth, a.gender, a.profile_image_path, a.is_private, a.is_banned, " +
                "a.website_address, c.likes_count, c.dislikes_count, c.exposure_count, c.click_count, " +
                "c.type, c.start_date, c.end_date, c.date_of_change ");
            queryBuilder.Append("FROM dbo.Campaign AS c, dbo.TargetAudience AS t, dbo.RegisteredUser AS a ");
            queryBuilder.Append("WHERE c.agent_id = a.id AND c.target_audience_id = t.id AND c.id = @Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return (Campaign)_campaignTarget.ConvertSql(
                dataTable.Rows[0], _userRepository.GetBlockedBy(Guid.Parse(dataTable.Rows[0][4].ToString())),
                        _userRepository.GetBlocking(Guid.Parse(dataTable.Rows[0][4].ToString())),
                        _userRepository.GetFollowing(Guid.Parse(dataTable.Rows[0][4].ToString())),
                        _userRepository.GetFollowers(Guid.Parse(dataTable.Rows[0][4].ToString())),
                        _userRepository.GetMutedBy(Guid.Parse(dataTable.Rows[0][4].ToString())),
                        _userRepository.GetMuted(Guid.Parse(dataTable.Rows[0][4].ToString())), new List<Ad>(),
                        new List<ExposureDate>()
                );
            }
            return Maybe<Campaign>.None;
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
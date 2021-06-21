using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroservice.Core.Interface.Repository;
using UserMicroservice.Core.Model;
using UserMicroservice.DataAccess.Adaptee;
using UserMicroservice.DataAccess.Adapter;
using UserMicroservice.DataAccess.Target;

namespace UserMicroservice.DataAccess.Implementation
{
    public class AgentRequestRepository : Repository, IAgentRequestRepository
    {
        public ITarget _agentRequestAdapter = new AgentRequestAdapter(new AgentRequestAdaptee());

        public AgentRequestRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<AgentRequest> GetAll()
        {
            throw new NotImplementedException();
        }

        public Maybe<AgentRequest> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public AgentRequest Save(AgentRequest agentRequest)
        {
            StringBuilder queryBuilder = new StringBuilder("INSERT INTO dbo.AgentRequest ");
            queryBuilder.Append("(id, is_approved, registered_user_id) ");
            queryBuilder.Append("VALUES (@id, @is_approved, @registered_user_id);");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = agentRequest.Id },
                new SqlParameter("@is_approved", SqlDbType.Bit) { Value = agentRequest.IsApproved },
                new SqlParameter("@registered_user_id", SqlDbType.UniqueIdentifier) { Value = agentRequest.RegisteredUser.Id },
            };

            ExecuteQuery(query, parameters);

            return agentRequest;
        }

        public AgentRequest Edit(AgentRequest agentRequest)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AgentRequest> GetBy(string isApproved)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT a.id, a.is_approved, r.id, r.username, r.email, r.first_name, r.last_name," +
                " r.date_of_birth, r.phone_number, r.gender, r.website_address, r.bio, r.is_private, r.is_accepting_messages, r.is_accepting_tags, " +
                " r.profile_picture_path, r.password, r.is_banned ");
            queryBuilder.Append("FROM dbo.AgentRequest as a, dbo.RegisteredUser as r ");
            queryBuilder.Append("WHERE r.id = a.registered_user_id ");

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!String.IsNullOrWhiteSpace(isApproved))
            {
                queryBuilder.Append("AND a.is_approved = @IsApproved");
                SqlParameter parameterIsApproved = new SqlParameter("@IsApproved", SqlDbType.Bit)
                { Value = isApproved.Equals("true") ? 1 : 0 };
                parameters.Add(parameterIsApproved);
            }

            string query = queryBuilder.ToString();

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows

                    select (AgentRequest)_agentRequestAdapter.ConvertSql(dataRow)).ToList();
        }
    }
}
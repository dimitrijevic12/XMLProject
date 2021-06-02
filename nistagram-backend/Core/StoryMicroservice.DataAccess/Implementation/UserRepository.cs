using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;
using StoryMicroservice.Core.Interface.Repository;
using StoryMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryMicroservice.DataAccess.Implementation
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public RegisteredUser Delete(RegisteredUser obj)
        {
            throw new NotImplementedException();
        }

        public RegisteredUser Edit(RegisteredUser obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegisteredUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public Maybe<RegisteredUser> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public RegisteredUser Save(RegisteredUser registeredUser)
        {
            StringBuilder queryBuilder = new StringBuilder("INSERT INTO dbo.RegisteredUser ");
            queryBuilder.Append("(id, username, first_name, last_name, isPrivate, isAcceptingTags) ");
            queryBuilder.Append("VALUES (@id, @username, @first_name, @last_name, @is_private, @is_accepting_tags);");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = registeredUser.Id },
                 new SqlParameter("@username", SqlDbType.NVarChar) { Value = registeredUser.Username.ToString() },
                 new SqlParameter("@first_name", SqlDbType.NVarChar) { Value = registeredUser.FirstName.ToString() },
                 new SqlParameter("@last_name", SqlDbType.NVarChar) { Value = registeredUser.LastName.ToString() },
                 new SqlParameter("@is_private", SqlDbType.Bit) { Value = registeredUser.IsPrivate },
                 new SqlParameter("@is_accepting_tags", SqlDbType.Bit) { Value = registeredUser.IsAcceptingTags },
             };

            ExecuteQuery(query, parameters);

            return registeredUser;
        }
    }
}
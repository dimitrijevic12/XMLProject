using Microsoft.Extensions.Configuration;
using PostMicroservice.Core.Interface.Repository;
using PostMicroservice.Core.Model;
using PostMicroservice.DataAccess.Adaptee;
using PostMicroservice.DataAccess.Adapter;
using PostMicroservice.DataAccess.Target;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PostMicroservice.DataAccess.Implementation
{
    public class UserRepository : Repository, IUserRepository
    {
        public ITarget _registeredUserTarget = new RegisteredUserAdapter(new RegisteredUserAdaptee());

        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<RegisteredUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public RegisteredUser GetById(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT * ");
            queryBuilder.Append("FROM dbo.RegisteredUser ");
            queryBuilder.Append("WHERE id = @Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            return (RegisteredUser)_registeredUserTarget.ConvertSql(
                ExecuteQuery(query, parameters).Rows[0]
            );
        }

        public RegisteredUser Save(RegisteredUser registeredUser)
        {
            StringBuilder queryBuilder = new StringBuilder("INSERT INTO dbo.RegisteredUser ");
            queryBuilder.Append("(id, username, first_name, last_name, is_private, is_accepting_tags) ");
            queryBuilder.Append("VALUES (@id, @username, @first_name, @last_name, @is_private, @is_accepting_tags);");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = registeredUser.Id },
                 new SqlParameter("@username", SqlDbType.NVarChar) { Value = registeredUser.Username.ToString() },
                 new SqlParameter("@first_name", SqlDbType.NVarChar) { Value = registeredUser.FirstName.ToString() },
                 new SqlParameter("@last_name", SqlDbType.NVarChar) { Value = registeredUser.LastName.ToString() },
                 new SqlParameter("@is_private", SqlDbType.Bit) { Value = registeredUser.IsPrivate },
                 new SqlParameter("@is_accepting_tags", SqlDbType.Bit) { Value = registeredUser.IsAcceptingTags }
             };

            ExecuteQuery(query, parameters);

            return registeredUser;
        }

        public RegisteredUser Edit(RegisteredUser obj)
        {
            throw new NotImplementedException();
        }

        public RegisteredUser Delete(RegisteredUser obj)
        {
            throw new NotImplementedException();
        }
    }
}
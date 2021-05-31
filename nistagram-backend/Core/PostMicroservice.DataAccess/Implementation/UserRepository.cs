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
using System.Linq;

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

        public RegisteredUser Save(RegisteredUser obj)
        {
            throw new NotImplementedException();
        }

        public RegisteredUser Edit(RegisteredUser obj)
        {
            throw new NotImplementedException();
        }

        public RegisteredUser Delete(RegisteredUser obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegisteredUser> GetTaggable()
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT * ");
            queryBuilder.Append("FROM dbo.RegisteredUser ");
            queryBuilder.Append("WHERE isAcceptingTags = 1;");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>();

            DataTable dataTable = ExecuteQuery(query, parameters);
            return (from DataRow dataRow in dataTable.Rows
                    select (RegisteredUser)_registeredUserTarget.ConvertSql(dataRow)).ToList();
        }
    }
}
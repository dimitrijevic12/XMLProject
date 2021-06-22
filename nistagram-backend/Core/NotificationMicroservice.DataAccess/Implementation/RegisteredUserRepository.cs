using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;
using NotificationMicroservice.Core.Interface.Repository;
using NotificationMicroservice.Core.Model;
using NotificationMicroservice.DataAccess.Adaptee;
using NotificationMicroservice.DataAccess.Adapter;
using NotificationMicroservice.DataAccess.Target;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace NotificationMicroservice.DataAccess.Implementation
{
    public class RegisteredUserRepository : Repository, IRegisteredUserRepository
    {
        public ITarget _registeredUserTarget = new RegisteredUserAdapter(new RegisteredUserAdaptee());

        public RegisteredUserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<RegisteredUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public Maybe<RegisteredUser> GetById(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT r.id, r.username, r.profilePicturePath ");
            queryBuilder.Append("FROM dbo.RegisteredUser AS r ");
            queryBuilder.Append("WHERE r.id = @Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return (RegisteredUser)_registeredUserTarget.ConvertSql(
                dataTable.Rows[0]);
            }
            return Maybe<RegisteredUser>.None;
        }

        public RegisteredUser Save(RegisteredUser registeredUser)
        {
            StringBuilder queryBuilder = new StringBuilder("INSERT INTO dbo.RegisteredUser ");
            queryBuilder.Append("(id, username, profilePicturePath) ");
            queryBuilder.Append("VALUES (@id, @username, @profilePicturePath);");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = registeredUser.Id },
                 new SqlParameter("@username", SqlDbType.NVarChar) { Value = registeredUser.Username.ToString() },
                 new SqlParameter("@profilePicturePath", SqlDbType.NVarChar) { Value = registeredUser.ProfilePicturePath.ToString() },
             };

            ExecuteQuery(query, parameters);

            return registeredUser;
        }

        public RegisteredUser Edit(RegisteredUser registeredUser)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Maybe<RegisteredUser> GetByUsername(string username)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT r.id, r.username, r.profilePicturePath ");
            queryBuilder.Append("FROM dbo.RegisteredUser AS r ");
            queryBuilder.Append("WHERE r.username = @Username;");

            string query = queryBuilder.ToString();

            SqlParameter parameterUsername = new SqlParameter("@Username", SqlDbType.NVarChar) { Value = username };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterUsername };

            DataTable dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return (RegisteredUser)_registeredUserTarget.ConvertSql(
                dataTable.Rows[0]);
            }
            return Maybe<RegisteredUser>.None;
        }
    }
}
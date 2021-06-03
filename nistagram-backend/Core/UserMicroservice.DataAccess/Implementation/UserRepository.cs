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
    public class UserRepository : Repository, IUserRepository
    {
        public ITarget _registeredUserTarget = new RegisteredUserAdapter(new RegisteredUserAdaptee());
        public ITarget _userModelTarget = new UserModelAdapter(new UserModelAdaptee());

        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public RegisteredUser Delete(RegisteredUser obj)
        {
            throw new NotImplementedException();
        }

        public RegisteredUser Edit(RegisteredUser registeredUser)
        {
            StringBuilder queryBuilder = new StringBuilder("UPDATE dbo.RegisteredUser ");
            queryBuilder.Append("SET username = @username, email = @email, first_name = @first_name, last_name = @last_name, date_of_birth = @date_of_birth, phone_number = @phone_number, gender = @gender, website_address = @website_address, bio = @bio ");
            queryBuilder.Append("WHERE id = @id;");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = registeredUser.Id },
                 new SqlParameter("@username", SqlDbType.NVarChar) { Value = registeredUser.Username.ToString() },
                 new SqlParameter("@email", SqlDbType.NVarChar) { Value = registeredUser.EmailAddress.ToString() },
                 new SqlParameter("@first_name", SqlDbType.NVarChar) { Value = registeredUser.FirstName.ToString() },
                 new SqlParameter("@last_name", SqlDbType.NVarChar) { Value = registeredUser.LastName.ToString() },
                 new SqlParameter("@date_of_birth", SqlDbType.NVarChar) { Value = registeredUser.DateOfBirth.ToString() },
                 new SqlParameter("@phone_number", SqlDbType.NVarChar) { Value = registeredUser.PhoneNumber.ToString() },
                 new SqlParameter("@gender", SqlDbType.NVarChar) { Value = registeredUser.Gender.ToString() },
                 new SqlParameter("@website_address", SqlDbType.NVarChar) { Value = registeredUser.WebsiteAddress.ToString() },
                 new SqlParameter("@bio", SqlDbType.NVarChar) { Value = registeredUser.Bio.ToString() },
            };

            ExecuteQuery(query, parameters);

            return registeredUser;
        }

        public IEnumerable<RegisteredUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public Maybe<RegisteredUser> GetById(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT * ");
            queryBuilder.Append("FROM dbo.RegisteredUser ");
            queryBuilder.Append("WHERE id = @Id;");

            string query = queryBuilder.ToString();

            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterId };

            DataTable dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return (RegisteredUser)_registeredUserTarget.ConvertSql(
                dataTable.Rows[0]
                );
            }
            return Maybe<RegisteredUser>.None;
        }

        public Maybe<RegisteredUser> GetByUsername(String username)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT * ");
            queryBuilder.Append("FROM dbo.RegisteredUser ");
            queryBuilder.Append("WHERE username = @Username;");

            string query = queryBuilder.ToString();

            SqlParameter parameterUsername = new SqlParameter("@Username", SqlDbType.NVarChar) { Value = username };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterUsername };

            DataTable dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return (RegisteredUser)_registeredUserTarget.ConvertSql(
                dataTable.Rows[0]
                );
            }
            return Maybe<RegisteredUser>.None;
        }

        public Maybe<User> GetRoleByUsername(String username)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT * ");
            queryBuilder.Append("FROM dbo.RegisteredUser ");
            queryBuilder.Append("WHERE username = @Username;");

            string query = queryBuilder.ToString();

            SqlParameter parameterUsername = new SqlParameter("@Username", SqlDbType.NVarChar) { Value = username };

            List<SqlParameter> parameters = new List<SqlParameter>() { parameterUsername };

            DataTable dataTable = ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                return (User)_userModelTarget.ConvertSql(
                dataTable.Rows[0]
                );
            }
            return Maybe<User>.None;
        }

        public IEnumerable<RegisteredUser> GetBy(string name, string access)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT * ");
            queryBuilder.Append("FROM dbo.RegisteredUser ");

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!String.IsNullOrWhiteSpace(name) || !String.IsNullOrWhiteSpace(access))
            {
                queryBuilder.Append("WHERE ");
                bool needsAnd = false;
                if (!String.IsNullOrWhiteSpace(name))
                {
                    if (needsAnd)
                        queryBuilder.Append("AND ");

                    queryBuilder.Append("LOWER(username) like LOWER(@Name) OR LOWER(first_name) like LOWER(@Name) OR LOWER(last_name) like LOWER(@Name)");
                    SqlParameter parameterName = new SqlParameter("@Name", SqlDbType.NVarChar) { Value = "%" + name + "%" };
                    parameters.Add(parameterName);
                    needsAnd = true;
                }
                if (!String.IsNullOrWhiteSpace(access))
                {
                    if (needsAnd)
                        queryBuilder.Append("AND ");

                    queryBuilder.Append("is_private = @Access ");

                    SqlParameter parameterHashTag = new SqlParameter("@Access", SqlDbType.Bit)
                    { Value = access.Equals("private") ? 1 : 0 };
                    parameters.Add(parameterHashTag);
                    needsAnd = true;
                }
            }

            string query = queryBuilder.ToString();

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows

                    select (RegisteredUser)_registeredUserTarget.ConvertSql(dataRow)).ToList();
        }

        public RegisteredUser Save(RegisteredUser registeredUser)
        {
            StringBuilder queryBuilder = new StringBuilder("INSERT INTO dbo.RegisteredUser ");
            queryBuilder.Append("(id, username, email, first_name, last_name, date_of_birth, phone_number, gender, website_address, bio, is_private, is_accepting_messages, is_accepting_tags, type, category, password) ");
            queryBuilder.Append("VALUES (@id, @username, @email, @first_name, @last_name, @date_of_birth, @phone_number, @gender, @website_address, @bio, @is_private, @is_accepting_messages, @is_accepting_tags, 'default', '', @password);");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = registeredUser.Id },
                 new SqlParameter("@username", SqlDbType.NVarChar) { Value = registeredUser.Username.ToString() },
                 new SqlParameter("@email", SqlDbType.NVarChar) { Value = registeredUser.EmailAddress.ToString() },
                 new SqlParameter("@first_name", SqlDbType.NVarChar) { Value = registeredUser.FirstName.ToString() },
                 new SqlParameter("@last_name", SqlDbType.NVarChar) { Value = registeredUser.LastName.ToString() },
                 new SqlParameter("@date_of_birth", SqlDbType.NVarChar) { Value = registeredUser.DateOfBirth.ToString() },
                 new SqlParameter("@phone_number", SqlDbType.NVarChar) { Value = registeredUser.PhoneNumber.ToString() },
                 new SqlParameter("@gender", SqlDbType.NVarChar) { Value = registeredUser.Gender.ToString() },
                 new SqlParameter("@website_address", SqlDbType.NVarChar) { Value = registeredUser.WebsiteAddress.ToString() },
                 new SqlParameter("@bio", SqlDbType.NVarChar) { Value = registeredUser.Bio.ToString() },
                 new SqlParameter("@is_private", SqlDbType.Bit) { Value = registeredUser.IsPrivate },
                 new SqlParameter("@is_accepting_messages", SqlDbType.Bit) { Value = registeredUser.IsAcceptingMessages },
                 new SqlParameter("@is_accepting_tags", SqlDbType.Bit) { Value = registeredUser.IsAcceptingTags },
                 new SqlParameter("@password", SqlDbType.NVarChar) { Value = registeredUser.Password.ToString() },
             };

            ExecuteQuery(query, parameters);

            return registeredUser;
        }

        public void Follow(Guid id, Guid followedById, Guid followingId)
        {
            StringBuilder queryBuilder = new StringBuilder("INSERT INTO dbo.Follows ");
            queryBuilder.Append("(id, followed_by_id, following_id) ");
            queryBuilder.Append("VALUES (@id, @followed_by_id, @following_id);");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = id },
                 new SqlParameter("@followed_by_id", SqlDbType.UniqueIdentifier) { Value = followedById },
                 new SqlParameter("@following_id", SqlDbType.UniqueIdentifier) { Value = followingId }
             };

            ExecuteQuery(query, parameters);
        }

        public void FollowPrivate(Guid id, Guid requests_follow_id, Guid recieves_follow_id)
        {
            StringBuilder queryBuilder = new StringBuilder("INSERT INTO dbo.FollowRequest ");
            queryBuilder.Append("(id, requests_follow_id, recieves_follow_id, timestamp, type, is_approved) ");
            queryBuilder.Append("VALUES (@id, @followed_by_id, @following_id, @timestamp, @type, @is_approved );");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = id },
                 new SqlParameter("@followed_by_id", SqlDbType.UniqueIdentifier) { Value = requests_follow_id },
                 new SqlParameter("@following_id", SqlDbType.UniqueIdentifier) { Value = recieves_follow_id },
                 new SqlParameter("@timestamp", SqlDbType.NVarChar) { Value = DateTime.Now },
                 new SqlParameter("@type", SqlDbType.NVarChar) { Value = "unappr" },
                 new SqlParameter("@is_approved", SqlDbType.Bit) { Value = false }
             };

            ExecuteQuery(query, parameters);
        }

        public Boolean AlreadyFollowing(Guid requests_follow_id, Guid recieves_follow_id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM dbo.Follows ");
            queryBuilder.Append("WHERE @followed_by_id = followed_by_id AND @following_id = following_id; ");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@followed_by_id", SqlDbType.UniqueIdentifier) { Value = requests_follow_id },
                 new SqlParameter("@following_id", SqlDbType.UniqueIdentifier) { Value = recieves_follow_id }
             };

            DataTable dataTable = ExecuteQuery(query, parameters);

            return dataTable.Rows.Count > 0;
        }

        public Boolean AlreadyFollowingPrivate(Guid requests_follow_id, Guid recieves_follow_id)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM dbo.FollowRequest ");
            queryBuilder.Append("WHERE @followed_by_id = requests_follow_id AND @following_id = recieves_follow_id AND (@type = type OR @is_approved = is_approved); ");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@followed_by_id", SqlDbType.UniqueIdentifier) { Value = requests_follow_id },
                 new SqlParameter("@following_id", SqlDbType.UniqueIdentifier) { Value = recieves_follow_id },
                 new SqlParameter("@type", SqlDbType.NVarChar) { Value = "unappr" },
                 new SqlParameter("@is_approved", SqlDbType.Bit) { Value = true }
             };

            DataTable dataTable = ExecuteQuery(query, parameters);

            return dataTable.Rows.Count > 0;
        }

        public void HandleFollowRequest(Guid id, String type, Boolean is_approved)
        {
            StringBuilder queryBuilder = new StringBuilder("UPDATE dbo.FollowRequest ");
            queryBuilder.Append("SET type = @type, is_approved = @is_approved ");
            queryBuilder.Append("WHERE id = @id;");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = id },
                 new SqlParameter("@type", SqlDbType.NVarChar) { Value = type },
                 new SqlParameter("@is_approved", SqlDbType.Bit) { Value = is_approved }
             };

            ExecuteQuery(query, parameters);
        }

        public IEnumerable<RegisteredUser> GetAllFollowingRequests(Guid id)
        {
            StringBuilder queryBuilder = new StringBuilder("f.id, f.timestamp, r.id, r.username, r.email, r.first_name, r.last_name, r.date_of_birth, " +
                "r.phone_number, r.gender, r.website_address, r.bio, r.is_private, r.is_accepting_messages, r.is_accepting_tags, r.password, r2.id," +
                " r2.username, r2.email, r2.first_name, r2.last_name, r2.date_of_birth, r2.phone_number, r2.gender, r2.website_address, r2.bio," +
                " r2.is_private, r2.is_accepting_messages, r2.is_accepting_tags, r2.password ");
            queryBuilder.Append("FROM dbo.RegisteredUser As r, dbo.FollowRequest As f, dbo.RegisteredUser As r2");
            queryBuilder.Append("WHERE r.id = f.requests_follow_id And f.recieves_follow_id = @id  And f.recieves_follow_id = r2.id ;");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = id }
             };

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows

                    select (RegisteredUser)_registeredUserTarget.ConvertSql(dataRow)).ToList();
        }
    }
}
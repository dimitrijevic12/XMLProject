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
using UserMicroservice.DataAccess.Target;

namespace UserMicroservice.DataAccess.Implementation
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

        public RegisteredUser GetById(int id)
        {
            throw new NotImplementedException();
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
                 new SqlParameter("@username", SqlDbType.VarChar) { Value = registeredUser.Username },
                 new SqlParameter("@email", SqlDbType.VarChar) { Value = registeredUser.EmailAddress },
                 new SqlParameter("@first_name", SqlDbType.VarChar) { Value = registeredUser.FirstName },
                 new SqlParameter("@last_name", SqlDbType.VarChar) { Value = registeredUser.LastName },
                 new SqlParameter("@date_of_birth", SqlDbType.VarChar) { Value = registeredUser.DateOfBirth },
                 new SqlParameter("@phone_number", SqlDbType.VarChar) { Value = registeredUser.PhoneNumber },
                 new SqlParameter("@gender", SqlDbType.VarChar) { Value = registeredUser.Gender },
                 new SqlParameter("@website_address", SqlDbType.VarChar) { Value = registeredUser.WebsiteAddress },
                 new SqlParameter("@bio", SqlDbType.VarChar) { Value = registeredUser.Bio },
                 new SqlParameter("@is_private", SqlDbType.Bit) { Value = registeredUser.IsPrivate },
                 new SqlParameter("@is_accepting_messages", SqlDbType.Bit) { Value = registeredUser.IsAcceptingMessages },
                 new SqlParameter("@is_accepting_tags", SqlDbType.Bit) { Value = registeredUser.IsAcceptingTags },
                 new SqlParameter("@password", SqlDbType.VarChar) { Value = registeredUser.Password },
             };

            ExecuteQuery(query, parameters);

            return registeredUser;
        }
    }
}
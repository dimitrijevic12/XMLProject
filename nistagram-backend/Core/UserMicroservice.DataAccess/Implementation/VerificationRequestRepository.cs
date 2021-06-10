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

namespace UserMicroservice.DataAccess.Implementation
{
    public class VerificationRequestRepository : Repository, IVerificationRequestRepository
    {
        public VerificationRequestRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public VerificationRequest Delete(VerificationRequest obj)
        {
            throw new NotImplementedException();
        }

        public VerificationRequest Edit(VerificationRequest obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VerificationRequest> GetAll()
        {
            throw new NotImplementedException();
        }

        public Maybe<VerificationRequest> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public VerificationRequest Save(VerificationRequest verificationRequest)
        {
            StringBuilder queryBuilder = new StringBuilder("INSERT INTO dbo.VerificationRequest ");
            queryBuilder.Append("(id, registered_user_id, first_name, last_name, category, document_image_path, is_approved) ");
            queryBuilder.Append("VALUES (@id, @registered_user_id, @first_name, @last_name, @category, @document_image_path, @is_approved);");

            string query = queryBuilder.ToString();

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = verificationRequest.Id },
                new SqlParameter("@registered_user_id", SqlDbType.UniqueIdentifier) { Value = verificationRequest.RegisteredUser.Id },
                 new SqlParameter("@first_name", SqlDbType.NVarChar) { Value = verificationRequest.FirstName.ToString() },
                 new SqlParameter("@last_name", SqlDbType.NVarChar) { Value = verificationRequest.LastName.ToString() },
                 new SqlParameter("@category", SqlDbType.NVarChar) { Value = verificationRequest.Category.ToString() },
                 new SqlParameter("@document_image_path", SqlDbType.NVarChar) { Value = verificationRequest.DocumentImagePath.ToString() },
                 new SqlParameter("@is_approved", SqlDbType.Bit) { Value = verificationRequest.IsApproved },
            };

            ExecuteQuery(query, parameters);

            return verificationRequest;
        }
    }
}
﻿using CSharpFunctionalExtensions;
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
    public class VerificationRequestRepository : Repository, IVerificationRequestRepository
    {
        public ITarget _verificationRequestTarget = new VerificationRequestAdapter(new VerificationRequestAdaptee());

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

        public IEnumerable<VerificationRequest> GetBy(string isApproved)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT v.id, r.id, r.username, r.email, r.first_name, r.last_name," +
                " r.date_of_birth, r.phone_number, r.gender, r.website_address, r.bio, r.is_private, r.is_accepting_messages, r.is_accepting_tags, r.type," +
                " r.category, r.password, v.first_name, v.last_name, v.category, v.document_image_path, v.is_approved ");
            queryBuilder.Append("FROM dbo.VerificationRequest as v, dbo.RegisteredUser as r ");
            queryBuilder.Append("WHERE r.id = v.registered_user_id ");

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!String.IsNullOrWhiteSpace(isApproved))
            {
                queryBuilder.Append("AND v.is_approved = @IsApproved");
                SqlParameter parameterIsApproved = new SqlParameter("@IsApproved", SqlDbType.Bit)
                { Value = isApproved.Equals("true") ? 1 : 0 };
                parameters.Add(parameterIsApproved);
            }

            string query = queryBuilder.ToString();

            DataTable dataTable = ExecuteQuery(query, parameters);

            return (from DataRow dataRow in dataTable.Rows

                    select (VerificationRequest)_verificationRequestTarget.ConvertSql(dataRow)).ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using UserMicroservice.Core.Model;

namespace UserMicroservice.DataAccess.Adaptee
{
    public class VerificationRequestAdaptee
    {
        public VerificationRequest ConvertSqlDataReaderToVerificationRequest(DataRow dataRow)
        {
            return VerificationRequest.Create(new Guid(dataRow[0].ToString()),
                            ConvertSqlDataReaderToRegisteredUser(dataRow),
                            VerificationRequestFirstName.Create(dataRow[17].ToString()).Value,
                            VerificationRequestLastName.Create(dataRow[18].ToString()).Value,
                            (Categories)Enum.Parse(typeof(Categories), dataRow[19].ToString()),
                            DocumentImagePath.Create(dataRow[20].ToString()).Value,
                            bool.Parse(dataRow[21].ToString())).Value;
        }

        private RegisteredUser ConvertSqlDataReaderToRegisteredUser(DataRow dataRow)
        {
            if (dataRow[14].ToString().Equals("RegisteredUser"))
                return RegisteredUser.Create(new Guid(dataRow[1].ToString()), Username.Create(dataRow[2].ToString()).Value,
                            EmailAddress.Create(dataRow[3].ToString()).Value, FirstName.Create(dataRow[4].ToString()).Value,
                            LastName.Create(dataRow[5].ToString()).Value, DateTime.Parse(dataRow[6].ToString()),
                            PhoneNumber.Create(dataRow[7].ToString()).Value, Gender.Create(dataRow[8].ToString()).Value,
                            WebsiteAddress.Create(dataRow[9].ToString()).Value, Bio.Create(dataRow[10].ToString()).Value, bool.Parse(dataRow[11].ToString()),
                            bool.Parse(dataRow[12].ToString()), bool.Parse(dataRow[13].ToString()), Password.Create(dataRow[16].ToString()).Value,
                            ProfileImagePath.Create(dataRow[15].ToString()).Value, new List<RegisteredUser>(), new List<RegisteredUser>(),
                            new List<RegisteredUser>(), new List<RegisteredUser>(), new List<RegisteredUser>(), new List<RegisteredUser>(),
                            new List<RegisteredUser>(), new List<RegisteredUser>()).Value;
            else
                return VerifiedUser.Create(new Guid(dataRow[1].ToString()), Username.Create(dataRow[2].ToString()).Value,
                            EmailAddress.Create(dataRow[3].ToString()).Value, FirstName.Create(dataRow[4].ToString()).Value,
                            LastName.Create(dataRow[5].ToString()).Value, DateTime.Parse(dataRow[6].ToString()),
                            PhoneNumber.Create(dataRow[7].ToString()).Value, Gender.Create(dataRow[8].ToString()).Value,
                            WebsiteAddress.Create(dataRow[9].ToString()).Value, Bio.Create(dataRow[10].ToString()).Value, bool.Parse(dataRow[11].ToString()),
                            bool.Parse(dataRow[12].ToString()), bool.Parse(dataRow[13].ToString()), Password.Create(dataRow[16].ToString()).Value,
                            ProfileImagePath.Create(dataRow[15].ToString()).Value, new List<RegisteredUser>(), new List<RegisteredUser>(),
                            new List<RegisteredUser>(), new List<RegisteredUser>(), new List<RegisteredUser>(), new List<RegisteredUser>(),
                            new List<RegisteredUser>(), new List<RegisteredUser>()).Value;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroservice.Core.Model;

namespace UserMicroservice.DataAccess.Adaptee
{
    public class UserModelAdaptee
    {
        public User ConvertSqlDataReaderToUserModel(DataRow dataRow)
        {
            if (dataRow[13].ToString().Equals("agentapp", StringComparison.InvariantCultureIgnoreCase))
            {
                return ConvertSqlDataReaderToApprovedAgent(dataRow);
            }
            else if (dataRow[13].ToString().Equals("agentden", StringComparison.InvariantCultureIgnoreCase))
            {
                return ConvertSqlDataReaderToDeniedAgent(dataRow);
            }
            else if (dataRow[13].ToString().Equals("agentuna", StringComparison.InvariantCultureIgnoreCase))
            {
                return ConvertSqlDataReaderToUnapprovedAgent(dataRow);
            }
            return ConvertSqlDataReaderToRegisteredUser(dataRow);
        }

        private RegisteredUser ConvertSqlDataReaderToRegisteredUser(DataRow dataRow)
        {
            return RegisteredUser.Create(Guid.Parse(dataRow[0].ToString()),
                                    Username.Create(dataRow[1].ToString()).Value,
                                    EmailAddress.Create(dataRow[2].ToString()).Value,
                                    FirstName.Create(dataRow[3].ToString()).Value,
                                    LastName.Create(dataRow[4].ToString()).Value,
                                    DateTime.Parse(dataRow[5].ToString()),
                                    PhoneNumber.Create(dataRow[6].ToString()).Value,
                                    Gender.Create(dataRow[7].ToString()).Value,
                                    WebsiteAddress.Create(dataRow[8].ToString()).Value,
                                    Bio.Create(dataRow[9].ToString()).Value,
                                    bool.Parse(dataRow[10].ToString()),
                                    bool.Parse(dataRow[11].ToString()),
                                    bool.Parse(dataRow[12].ToString()),
                                    Password.Create(dataRow[15].ToString()).Value,
                                    ProfileImagePath.Create(dataRow[16].ToString()).Value,
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    bool.Parse(dataRow[17].ToString())).Value;
        }

        private ApprovedAgent ConvertSqlDataReaderToApprovedAgent(DataRow dataRow)
        {
            return ApprovedAgent.Create(Guid.Parse(dataRow[0].ToString()),
                                    Username.Create(dataRow[1].ToString()).Value,
                                    EmailAddress.Create(dataRow[2].ToString()).Value,
                                    FirstName.Create(dataRow[3].ToString()).Value,
                                    LastName.Create(dataRow[4].ToString()).Value,
                                    DateTime.Parse(dataRow[5].ToString()),
                                    PhoneNumber.Create(dataRow[6].ToString()).Value,
                                    Gender.Create(dataRow[7].ToString()).Value,
                                    WebsiteAddress.Create(dataRow[8].ToString()).Value,
                                    Bio.Create(dataRow[9].ToString()).Value,
                                    bool.Parse(dataRow[10].ToString()),
                                    bool.Parse(dataRow[11].ToString()),
                                    bool.Parse(dataRow[12].ToString()),
                                    Password.Create(dataRow[15].ToString()).Value,
                                    ProfileImagePath.Create(dataRow[16].ToString()).Value,
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    bool.Parse(dataRow[17].ToString())).Value;
        }

        private UnapprovedAgent ConvertSqlDataReaderToUnapprovedAgent(DataRow dataRow)
        {
            return UnapprovedAgent.Create(Guid.Parse(dataRow[0].ToString()),
                                    Username.Create(dataRow[1].ToString()).Value,
                                    EmailAddress.Create(dataRow[2].ToString()).Value,
                                    FirstName.Create(dataRow[3].ToString()).Value,
                                    LastName.Create(dataRow[4].ToString()).Value,
                                    DateTime.Parse(dataRow[5].ToString()),
                                    PhoneNumber.Create(dataRow[6].ToString()).Value,
                                    Gender.Create(dataRow[7].ToString()).Value,
                                    WebsiteAddress.Create(dataRow[8].ToString()).Value,
                                    Bio.Create(dataRow[9].ToString()).Value,
                                    bool.Parse(dataRow[10].ToString()),
                                    bool.Parse(dataRow[11].ToString()),
                                    bool.Parse(dataRow[12].ToString()),
                                    Password.Create(dataRow[15].ToString()).Value,
                                    ProfileImagePath.Create(dataRow[16].ToString()).Value,
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    bool.Parse(dataRow[17].ToString())).Value;
        }

        private DeniedAgent ConvertSqlDataReaderToDeniedAgent(DataRow dataRow)
        {
            return DeniedAgent.Create(Guid.Parse(dataRow[0].ToString()),
                                    Username.Create(dataRow[1].ToString()).Value,
                                    EmailAddress.Create(dataRow[2].ToString()).Value,
                                    FirstName.Create(dataRow[3].ToString()).Value,
                                    LastName.Create(dataRow[4].ToString()).Value,
                                    DateTime.Parse(dataRow[5].ToString()),
                                    PhoneNumber.Create(dataRow[6].ToString()).Value,
                                    Gender.Create(dataRow[7].ToString()).Value,
                                    WebsiteAddress.Create(dataRow[8].ToString()).Value,
                                    Bio.Create(dataRow[9].ToString()).Value,
                                    bool.Parse(dataRow[10].ToString()),
                                    bool.Parse(dataRow[11].ToString()),
                                    bool.Parse(dataRow[12].ToString()),
                                    Password.Create(dataRow[15].ToString()).Value,
                                    ProfileImagePath.Create(dataRow[16].ToString()).Value,
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    new List<Core.Model.RegisteredUser>(),
                                    bool.Parse(dataRow[17].ToString())).Value;
        }
    }
}
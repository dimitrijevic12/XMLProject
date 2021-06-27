using NotificationMicroservice.Core.Model;
using System;
using System.Data;

namespace NotificationMicroservice.DataAccess.Adaptee
{
    public class RegisteredUserAdaptee
    {
        public RegisteredUser ConvertSqlDataReaderToRegisteredUser(DataRow dataRow)
        {
            return RegisteredUser.Create(
                    id: Guid.Parse(dataRow[0].ToString().Trim()),
                    username: Username.Create(dataRow[1].ToString().Trim()).Value,
                    profilePicturePath: ProfilePicturePath.Create(dataRow[2].ToString().Trim()).Value).Value;
        }
    }
}
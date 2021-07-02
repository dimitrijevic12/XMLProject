using CampaignMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace CampaignService.DataAccess.Adaptee
{
    public class RegisteredUserAdaptee
    {
        public RegisteredUser ConvertSqlDataReaderToRegisteredUser(DataRow dataRow,
             IEnumerable<RegisteredUser> blockedUsers, IEnumerable<RegisteredUser> blockedByUsers,
             IEnumerable<RegisteredUser> mutedUsers, IEnumerable<RegisteredUser> mutedByUsers,
             IEnumerable<RegisteredUser> following, IEnumerable<RegisteredUser> followers)
        {
            return RegisteredUser.Create(Guid.Parse(dataRow[0].ToString()),
                                    Username.Create(dataRow[1].ToString()).Value,
                                    FirstName.Create(dataRow[9].ToString()).Value,
                                    LastName.Create(dataRow[10].ToString()).Value,
                                    DateTime.Parse(dataRow[2].ToString()),
                                    Gender.Create(dataRow[3].ToString()).Value,
                                    ProfileImagePath.Create(dataRow[6].ToString()).Value,
                                    /*WebsiteAddress.Create(dataRow[8].ToString()).Value,
                                    Category.Create(dataRow[5].ToString()).Value,*/
                                    bool.Parse(dataRow[7].ToString()),
                                    blockedUsers,
                                    blockedByUsers,
                                    mutedUsers,
                                    mutedByUsers,
                                    following,
                                    followers,
                                    bool.Parse(dataRow[11].ToString())).Value;
        }
    }
}
using CampaignMicroservice.Core.Model;
using CampaignService.DataAccess.Adaptee;
using CampaignService.DataAccess.Target;
using System.Collections.Generic;
using System.Data;

namespace CampaignService.DataAccess.Adapter
{
    public class RegisteredUserAdapter
    {
        private readonly RegisteredUserAdaptee registeredUserAdaptee;

        public RegisteredUserAdapter(RegisteredUserAdaptee registeredUserAdaptee)
        {
            this.registeredUserAdaptee = registeredUserAdaptee;
        }

        public object ConvertSql(DataRow dataRow, IEnumerable<RegisteredUser> blockedUsers,
            IEnumerable<RegisteredUser> blockedByUsers, IEnumerable<RegisteredUser> mutedUsers,
            IEnumerable<RegisteredUser> mutedByUsers, IEnumerable<RegisteredUser> following,
            IEnumerable<RegisteredUser> followers)
        {
            return registeredUserAdaptee.ConvertSqlDataReaderToUserModel(dataRow, blockedUsers,
                blockedByUsers, mutedUsers, mutedByUsers, following, followers);
        }
    }
}
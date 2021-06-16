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
                    notificationOptions: NotificationOptions.Create(
                        id: Guid.Parse(dataRow[3].ToString().Trim()),
                        isNotifiedByFollowRequests: bool.Parse(dataRow[4].ToString().Trim()),
                        isNotifiedByMessages: bool.Parse(dataRow[5].ToString().Trim()),
                        isNotifiedByPosts: bool.Parse(dataRow[6].ToString().Trim()),
                        isNotifiedByStories: bool.Parse(dataRow[7].ToString().Trim()),
                        isNotifiedByComments: bool.Parse(dataRow[8].ToString().Trim())
                        ).Value,
                    profilePicturePath: ProfilePicturePath.Create(dataRow[2].ToString().Trim()).Value).Value;
        }
    }
}
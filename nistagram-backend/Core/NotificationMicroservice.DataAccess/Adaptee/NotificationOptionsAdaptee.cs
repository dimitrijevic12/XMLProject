using NotificationMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationMicroservice.DataAccess.Adaptee
{
    public class NotificationOptionsAdaptee
    {
        public NotificationOptions ConvertSqlDataReaderToNotificationOptions(DataRow dataRow)
        {
            return NotificationOptions.Create(
                        id: Guid.Parse(dataRow[0].ToString().Trim()),
                        isNotifiedByFollowRequests: bool.Parse(dataRow[1].ToString().Trim()),
                        isNotifiedByMessages: bool.Parse(dataRow[2].ToString().Trim()),
                        isNotifiedByPosts: bool.Parse(dataRow[3].ToString().Trim()),
                        isNotifiedByStories: bool.Parse(dataRow[4].ToString().Trim()),
                        isNotifiedByComments: bool.Parse(dataRow[5].ToString().Trim()),
                        loggedUser: RegisteredUser.Create(
                            id: Guid.Parse(dataRow[6].ToString().Trim()),
                            username: Username.Create(dataRow[7].ToString().Trim()).Value,
                            profilePicturePath: ProfilePicturePath.Create(dataRow[8].ToString().Trim()).Value).Value,
                        notificationByUser: RegisteredUser.Create(
                            id: Guid.Parse(dataRow[9].ToString().Trim()),
                            username: Username.Create(dataRow[10].ToString().Trim()).Value,
                            profilePicturePath: ProfilePicturePath.Create(dataRow[11].ToString().Trim()).Value).Value).Value;
        }
    }
}
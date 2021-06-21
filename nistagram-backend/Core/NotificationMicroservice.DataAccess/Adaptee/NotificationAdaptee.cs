using NotificationMicroservice.Core.Model;
using System;
using System.Data;

namespace NotificationMicroservice.DataAccess.Adaptee
{
    public class NotificationAdaptee
    {
        public Notification ConvertSqlDataReaderToNotification(DataRow dataRow)
        {
            if (dataRow[2].ToString().Trim().Equals("post", StringComparison.InvariantCultureIgnoreCase))
            {
                return ConvertWithPost(dataRow);
            }
            else if (dataRow[2].ToString().Trim().Equals("story", StringComparison.InvariantCultureIgnoreCase))
            {
                return ConvertWithStory(dataRow);
            }
            else if (dataRow[2].ToString().Trim().Equals("comment", StringComparison.InvariantCultureIgnoreCase))
            {
                return ConvertWithComment(dataRow);
            }
            else if (dataRow[2].ToString().Trim().Equals("followRequest", StringComparison.InvariantCultureIgnoreCase))
            {
                return ConvertWithFollowRequest(dataRow);
            }
            else
            {
                return ConvertWithMessage(dataRow);
            }
        }

        private Notification ConvertWithPost(DataRow dataRow)
        {
            return Notification.Create(
                id: Guid.Parse(dataRow[0].ToString().Trim()),
                timestamp: DateTime.Parse(dataRow[1].ToString().Trim()),
                content: Post.Create(Guid.Parse(dataRow[3].ToString().Trim())).Value,
                registeredUser: RegisteredUser.Create(
                    id: Guid.Parse(dataRow[4].ToString().Trim()),
                    username: Username.Create(dataRow[5].ToString().Trim()).Value,
                    profilePicturePath: ProfilePicturePath.Create(dataRow[6].ToString().Trim()).Value).Value).Value;
        }

        private Notification ConvertWithStory(DataRow dataRow)
        {
            return Notification.Create(
                id: Guid.Parse(dataRow[0].ToString().Trim()),
                timestamp: DateTime.Parse(dataRow[1].ToString().Trim()),
                content: Story.Create(Guid.Parse(dataRow[3].ToString().Trim())).Value,
                registeredUser: RegisteredUser.Create(
                    id: Guid.Parse(dataRow[4].ToString().Trim()),
                    username: Username.Create(dataRow[5].ToString().Trim()).Value,
                    profilePicturePath: ProfilePicturePath.Create(dataRow[6].ToString().Trim()).Value).Value).Value;
        }

        private Notification ConvertWithComment(DataRow dataRow)
        {
            return Notification.Create(
                id: Guid.Parse(dataRow[0].ToString().Trim()),
                timestamp: DateTime.Parse(dataRow[1].ToString().Trim()),
                content: Comment.Create(Guid.Parse(dataRow[3].ToString().Trim())).Value,
                registeredUser: RegisteredUser.Create(
                    id: Guid.Parse(dataRow[4].ToString().Trim()),
                    username: Username.Create(dataRow[5].ToString().Trim()).Value,
                    profilePicturePath: ProfilePicturePath.Create(dataRow[6].ToString().Trim()).Value).Value).Value;
        }

        private Notification ConvertWithFollowRequest(DataRow dataRow)
        {
            return Notification.Create(
                id: Guid.Parse(dataRow[0].ToString().Trim()),
                timestamp: DateTime.Parse(dataRow[1].ToString().Trim()),
                content: FollowRequest.Create(Guid.Parse(dataRow[3].ToString().Trim())).Value,
                registeredUser: RegisteredUser.Create(
                    id: Guid.Parse(dataRow[4].ToString().Trim()),
                    username: Username.Create(dataRow[5].ToString().Trim()).Value,
                    profilePicturePath: ProfilePicturePath.Create(dataRow[6].ToString().Trim()).Value).Value).Value;
        }

        private Notification ConvertWithMessage(DataRow dataRow)
        {
            return Notification.Create(
                id: Guid.Parse(dataRow[0].ToString().Trim()),
                timestamp: DateTime.Parse(dataRow[1].ToString().Trim()),
                content: Message.Create(Guid.Parse(dataRow[3].ToString().Trim())).Value,
                registeredUser: RegisteredUser.Create(
                    id: Guid.Parse(dataRow[4].ToString().Trim()),
                    username: Username.Create(dataRow[5].ToString().Trim()).Value,
                    profilePicturePath: ProfilePicturePath.Create(dataRow[6].ToString().Trim()).Value).Value).Value;
        }
    }
}
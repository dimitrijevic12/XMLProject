using PostMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace PostMicroservice.DataAccess.Adaptee
{
    public class PostAlbumAdaptee
    {
        public PostAlbum ConvertSqlDataReaderToPostAlbum(DataRow dataRow)
        {
            return PostAlbum.Create(
                id: Guid.Parse(dataRow[0].ToString().Trim()),
                timeStamp: DateTime.Parse(dataRow[1].ToString().Trim()),
                description: Description.Create(dataRow[2].ToString().Trim()).Value,
                registeredUser: RegisteredUser.Create(
                                        id: Guid.Parse(dataRow[3].ToString().Trim()),
                                        username: Username.Create(dataRow[4].ToString().Trim()).Value,
                                        firstName: FirstName.Create(dataRow[5].ToString().Trim()).Value,
                                        lastName: LastName.Create(dataRow[6].ToString().Trim()).Value,
                                        isPrivate: bool.Parse(dataRow[7].ToString().Trim()),
                                        isAcceptingTags: bool.Parse(dataRow[8].ToString().Trim())).Value,
                likes: new List<RegisteredUser>(),
                dislikes: new List<RegisteredUser>(),
                comments: new List<Comment>(),
                location: Location.Create(id: Guid.Parse(dataRow[9].ToString().Trim()),
                                          street: Street.Create(dataRow[10].ToString().Trim()).Value,
                                          cityName: CityName.Create(dataRow[11].ToString().Trim()).Value,
                                          country: Country.Create(dataRow[12].ToString().Trim()).Value).Value,
                contentPaths: new List<ContentPath>()).Value;
        }
    }
}
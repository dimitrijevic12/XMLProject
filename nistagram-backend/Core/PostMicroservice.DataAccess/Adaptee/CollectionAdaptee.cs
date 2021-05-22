using PostMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace PostMicroservice.DataAccess.Adaptee
{
    public class CollectionAdaptee
    {
        public Collection ConvertSqlDataReaderToCollection(DataRow dataRow)
        {
            return Collection.Create(id: Guid.Parse(dataRow[0].ToString().Trim()),
                                     collectionName: CollectionName.Create(dataRow[1].ToString().Trim()).Value,
                                     posts: new List<Post>()).Value;
        }
    }
}
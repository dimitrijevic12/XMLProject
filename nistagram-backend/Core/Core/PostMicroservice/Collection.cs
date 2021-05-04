using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace Core.PostMicroservice
{
    public class Collection
    {
        private readonly Guid id;
        private readonly CollectionName collectionName;
        private readonly IEnumerable<Post> posts;

        public Collection(Guid id, CollectionName collectionName, IEnumerable<Post> posts)
        {
            this.id = id;
            this.collectionName = collectionName;
            this.posts = posts;
        }

        public static Result<Collection> Create(Guid id, CollectionName collectionName, IEnumerable<Post> posts)
        {
            return Result.Success(new Collection(id, collectionName, posts));
        }
    }
}
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace Core.StoryMicroservice
{
    public class Highlights
    {
        private readonly Guid id;
        private readonly CollectionName collectionName;
        private readonly IEnumerable<Story> stories;

        public Highlights(Guid id, CollectionName collectionName, IEnumerable<Story> stories)
        {
            this.id = id;
            this.collectionName = collectionName;
            this.stories = stories;
        }

        public static Result<Highlights> Create(Guid id, CollectionName collectionName, IEnumerable<Story> stories)
        {
            return Result.Success(new Highlights(id, collectionName, stories));
        }
    }
}
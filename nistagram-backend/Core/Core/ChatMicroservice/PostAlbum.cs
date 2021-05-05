using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace Core.ChatMicroservice
{
    public class PostAlbum : Content
    {
        private readonly IEnumerable<ContentPath> contentPaths;
        private Description description;

        public PostAlbum(Guid id, DateTime timestamp, IEnumerable<ContentPath> contentPaths, Description description) : base(id, timestamp)
        {
            this.contentPaths = contentPaths;
            this.description = description;
        }

        public static Result<PostAlbum> Create(Guid id, DateTime timestamp, IEnumerable<ContentPath> contentPaths, Description description)
        {
            return Result.Success(new PostAlbum(id, timestamp, contentPaths, description));
        }
    }
}
using CSharpFunctionalExtensions;
using System;

namespace ChatMicroservice.Core.Model
{
    public class Post : Content
    {
        private readonly ContentPath contentPath;
        private readonly Description description;

        public Post(Guid id, DateTime timestamp, ContentPath contentPath, Description description) : base(id, timestamp)
        {
            this.contentPath = contentPath;
            this.description = description;
        }

        public static Result<Post> Create(Guid id, DateTime timestamp, ContentPath contentPath, Description description)
        {
            return Result.Success(new Post(id, timestamp, contentPath, description));
        }
    }
}
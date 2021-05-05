using CSharpFunctionalExtensions;
using System;

namespace Core.StoryMicroservice
{
    public class Story
    {
        private Guid id;
        private readonly ContentPath contentPath;
        private readonly DateTime timeStamp;

        public Story(Guid id, ContentPath contentPath, DateTime timeStamp)
        {
            this.id = id;
            this.contentPath = contentPath;
            this.timeStamp = timeStamp;
        }

        public static Result<Story> Create(Guid id, ContentPath contentPath, DateTime timeStamp)
        {
            return Result.Success(new Story(id, contentPath, timeStamp));
        }
    }
}
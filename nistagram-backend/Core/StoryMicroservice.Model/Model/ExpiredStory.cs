using CSharpFunctionalExtensions;
using System;

namespace StoryMicroservice.Core.Model
{
    public class ExpiredStory : Story
    {
        private ExpiredStory(Guid id, ContentPath contentPath, DateTime timeStamp, Duration duration) : base(id, contentPath, timeStamp, duration)
        {
        }

        public static new Result<ExpiredStory> Create(Guid id, ContentPath contentPath, DateTime timeStamp, Duration duration)
        {
            return Result.Success(new ExpiredStory(id, contentPath, timeStamp, duration));
        }
    }
}
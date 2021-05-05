using CSharpFunctionalExtensions;
using System;

namespace Core.StoryMicroservice
{
    public class ExpiredStory : Story
    {
        private ExpiredStory(Guid id, ContentPath contentPath, DateTime timeStamp) : base(id, contentPath, timeStamp)
        {
        }

        public static new Result<ExpiredStory> Create(Guid id, ContentPath contentPath, DateTime timeStamp)
        {
            return Result.Success(new ExpiredStory(id, contentPath, timeStamp));
        }
    }
}
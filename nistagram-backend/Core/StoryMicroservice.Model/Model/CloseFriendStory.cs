using CSharpFunctionalExtensions;
using System;

namespace StoryMicroservice.Core.Model
{
    public class CloseFriendStory : Story
    {
        private CloseFriendStory(Guid id, ContentPath contentPath, DateTime timeStamp, Duration duration) : base(id, contentPath, timeStamp, duration)
        {
        }

        public static new Result<CloseFriendStory> Create(Guid id, ContentPath contentPath, DateTime timeStamp, Duration duration)
        {
            return Result.Success(new CloseFriendStory(id, contentPath, timeStamp, duration));
        }
    }
}
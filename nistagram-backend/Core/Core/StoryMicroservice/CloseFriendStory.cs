using CSharpFunctionalExtensions;
using System;

namespace Core.StoryMicroservice
{
    public class CloseFriendStory : Story
    {
        private CloseFriendStory(Guid id, ContentPath contentPath, DateTime timeStamp) : base(id, contentPath, timeStamp)
        {
        }

        public static new Result<CloseFriendStory> Create(Guid id, ContentPath contentPath, DateTime timeStamp)
        {
            return Result.Success(new CloseFriendStory(id, contentPath, timeStamp));
        }
    }
}
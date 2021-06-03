using CSharpFunctionalExtensions;
using System;

namespace StoryMicroservice.Core.Model
{
    public class Story
    {
        public Guid Id { get; }
        public ContentPath ContentPath { get; }
        public DateTime TimeStamp { get; }
        public Duration Duration { get; }

        public Story(Guid id, ContentPath contentPath, DateTime timeStamp, Duration duration)
        {
            Id = id;
            ContentPath = contentPath;
            TimeStamp = timeStamp;
            Duration = duration;
        }

        public static Result<Story> Create(Guid id, ContentPath contentPath, DateTime timeStamp, Duration duration)
        {
            return Result.Success(new Story(id, contentPath, timeStamp, duration));
        }
    }
}
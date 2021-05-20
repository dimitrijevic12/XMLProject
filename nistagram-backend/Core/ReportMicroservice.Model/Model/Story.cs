using CSharpFunctionalExtensions;
using System;

namespace ReportMicroservice.Core.Model
{
    public class Story : Content
    {
        private readonly ContentPath contentPath;

        public Story(Guid id, DateTime timestamp, ContentPath contentPath) : base(id, timestamp)
        {
            this.contentPath = contentPath;
        }

        public static Result<Story> Create(Guid id, DateTime timestamp, ContentPath contentPath)
        {
            return Result.Success(new Story(id, timestamp, contentPath));
        }
    }
}
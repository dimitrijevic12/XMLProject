using CSharpFunctionalExtensions;
using System;

namespace Core.ReportMicroservice
{
    public class Report
    {
        private readonly Guid id;
        private readonly DateTime timestamp;
        private readonly ReportReason reportReason;
        private readonly Content content;

        private Report(Guid id, DateTime timestamp, ReportReason reportReason, Content content)
        {
            this.id = id;
            this.timestamp = timestamp;
            this.reportReason = reportReason;
            this.content = content;
        }

        public static Result<Report> Create(Guid id, DateTime timestamp, ReportReason reportReason, Content content)
        {
            return Result.Success(new Report(id, timestamp, reportReason, content));
        }
    }
}
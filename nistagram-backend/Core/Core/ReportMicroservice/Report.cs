using CSharpFunctionalExtensions;
using System;

namespace Core.ReportMicroservice
{
    public class Report
    {
        private readonly DateTime timestamp;
        private readonly ReportReason reportReason;
        private readonly Content content;

        private Report(DateTime timestamp, ReportReason reportReason, Content content)
        {
            this.timestamp = timestamp;
            this.reportReason = reportReason;
            this.content = content;
        }

        public static Result<Report> Create(DateTime timestamp, ReportReason reportReason, Content content)
        {
            return Result.Success(new Report(timestamp, reportReason, content));
        }
    }
}
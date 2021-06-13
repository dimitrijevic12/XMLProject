using CSharpFunctionalExtensions;
using System;

namespace ReportMicroservice.Core.Model
{
    public class Report
    {
        public Guid Id { get; }
        public DateTime TimeStamp { get; }
        public ReportReason ReportReason { get; }
        public RegisteredUser RegisteredUser { get; }
        public Content Content { get; }

        private Report(Guid id, DateTime timestamp, ReportReason reportReason, RegisteredUser registeredUser,
            Content content)
        {
            Id = id;
            TimeStamp = timestamp;
            ReportReason = reportReason;
            RegisteredUser = registeredUser;
            Content = content;
        }

        public static Result<Report> Create(Guid id, DateTime timestamp, ReportReason reportReason,
            RegisteredUser registeredUser, Content content)
        {
            return Result.Success(new Report(id, timestamp, reportReason, registeredUser, content));
        }
    }
}
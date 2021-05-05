using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace Core.ReportMicroservice
{
    public class ReportReason : ValueObject
    {
        private readonly string reason;

        private ReportReason(string reason)
        {
            this.reason = reason;
        }

        public static Result<ReportReason> Create(string reason)
        {
            if (String.IsNullOrWhiteSpace(reason)) return Result.Failure<ReportReason>("Reason for reporting cannot be empty.");
            if (reason.Length > 50) return Result.Failure<ReportReason>("Reason for reporting cannot contain more than 50 characters.");
            return Result.Success(new ReportReason(reason));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return reason;
        }

        public static implicit operator string(ReportReason reportReason) => reportReason.reason;
    }
}
using CSharpFunctionalExtensions;
using System;

namespace Core.UserMicroservice
{
    public class VerificationRequest
    {
        private readonly Guid id;
        private readonly DocumentImagePath documentImagePath;
        private readonly bool approved;

        private VerificationRequest(Guid id, DocumentImagePath documentImagePath, bool approved)
        {
            this.id = id;
            this.documentImagePath = documentImagePath;
            this.approved = approved;
        }

        public static Result<VerificationRequest> Create(Guid id, DocumentImagePath documentImagePath, bool approved)
        {
            return Result.Success(new VerificationRequest(id, documentImagePath, approved));
        }
    }
}
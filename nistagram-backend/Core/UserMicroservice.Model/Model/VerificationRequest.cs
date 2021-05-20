using CSharpFunctionalExtensions;
using System;

namespace UserMicroservice.Core.Model
{
    public class VerificationRequest
    {
        private readonly bool isApproved;
        private readonly DocumentImagePath documentImagePath;
        private readonly Guid id;
        private readonly RegisteredUser registeredUser;

        private VerificationRequest(Guid id, DocumentImagePath documentImagePath, bool isApproved, RegisteredUser registeredUser)
        {
            this.id = id;
            this.documentImagePath = documentImagePath;
            this.isApproved = isApproved;
            this.registeredUser = registeredUser;
        }

        public static Result<VerificationRequest> Create(Guid id, DocumentImagePath documentImagePath,
            bool isApproved, RegisteredUser registeredUser)
        {
            return Result.Success(new VerificationRequest(id, documentImagePath, isApproved, registeredUser));
        }
    }
}
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroservice.Core.Interface.Repository;
using UserMicroservice.Core.Model;

namespace UserMicroservice.Core.Services
{
    public class VerificationRequestService
    {
        private readonly IVerificationRequestRepository _verificationRequestRepository;

        public VerificationRequestService(IVerificationRequestRepository verificationRequestRepository)
        {
            _verificationRequestRepository = verificationRequestRepository;
        }

        public Result Create(VerificationRequest verificationRequest)
        {
            if (_verificationRequestRepository.GetById(verificationRequest.Id).HasValue)
                return Result.Failure("Verification request with that Id already exists");
            return Result.Success(_verificationRequestRepository.Save(verificationRequest));
        }

        public Result Delete(Guid id)
        {
            if (_verificationRequestRepository.GetById(id).HasNoValue)
                return Result.Failure("Verification request with that Id does not exists");
            _verificationRequestRepository.Delete(id);
            return Result.Success();
        }
    }
}
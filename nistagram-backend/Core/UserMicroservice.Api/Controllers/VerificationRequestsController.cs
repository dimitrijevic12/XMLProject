using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Core.Interface.Repository;
using UserMicroservice.Core.Model;
using UserMicroservice.Core.Services;
using UserMicroservice.DataAccess.Implementation;

namespace UserMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificationRequestsController : Controller
    {
        private readonly VerificationRequestService _verificationRequestService;
        private readonly IUserRepository _userRepository;

        public VerificationRequestsController(VerificationRequestService verificationRequestService, IUserRepository userRepository)
        {
            _verificationRequestService = verificationRequestService;
            _userRepository = userRepository;
        }

        [Authorize(Roles = "RegisteredUser")]
        [HttpPost]
        public IActionResult Create(DTOs.VerificationRequest verificationRequest)
        {
            Guid id = Guid.NewGuid();
            Result<VerificationRequestFirstName> firstName = VerificationRequestFirstName.Create(verificationRequest.FirstName);
            Result<VerificationRequestLastName> lastName = VerificationRequestLastName.Create(verificationRequest.LastName);
            Result<DocumentImagePath> documentImagePath = DocumentImagePath.Create(verificationRequest.DocumentImagePath);
            if (!Enum.IsDefined(typeof(Categories), verificationRequest.Category)) return BadRequest("Category doesn't exist.");
            Result result = Result.Combine(firstName, lastName, documentImagePath);
            if (result.IsFailure) return BadRequest(result.Error);

            Maybe<RegisteredUser> user = _userRepository.GetById(verificationRequest.RegisteredUserId);
            if (user.HasNoValue) return BadRequest("Registered user doesn't exist.");

            if (_verificationRequestService.Create(VerificationRequest.Create(id, user.Value, firstName.Value, lastName.Value,
                (Categories)Enum.Parse(typeof(Categories), verificationRequest.Category), documentImagePath.Value, false).Value).IsFailure)
                return BadRequest("Couldn't create verification request");

            return Created(this.Request.Path + id, "");
        }
    }
}
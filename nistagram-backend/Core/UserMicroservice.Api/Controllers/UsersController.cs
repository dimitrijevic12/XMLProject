using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Api.DTOs;
using UserMicroservice.Api.Factories;
using UserMicroservice.Core.Interface.Repository;
using UserMicroservice.Core.Interface.Service;
using UserMicroservice.Core.Model;
using UserMicroservice.Core.Model.File;
using UserMicroservice.Core.Services;
using UserMicroservice.DataAccess.Implementation;

namespace UserMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;
        private readonly RegisteredUserFactory registerUserFactory;
        private readonly IUserRepository _userRepository;
        private readonly FollowRequestFactory followRequestFactory;
        private readonly IWebHostEnvironment _env;

        public UsersController(UserService userService, IUserRepository userRepository,
            RegisteredUserFactory registerUserFactory, FollowRequestFactory followRequestFactory,
            IWebHostEnvironment env)
        {
            this.userService = userService;
            _userRepository = userRepository;
            this.registerUserFactory = registerUserFactory;
            this.followRequestFactory = followRequestFactory;
            _env = env;
        }

        //[Authorize(Roles = "ApprovedAgent")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(DTOs.RegisteredUser dto)
        {
            Guid id = Guid.NewGuid();

            Result<Username> username = Username.Create(dto.Username);
            Result<EmailAddress> emailAddress = EmailAddress.Create(dto.EmailAddress);
            Result<FirstName> firstName = FirstName.Create(dto.FirstName);
            Result<LastName> lastName = LastName.Create(dto.LastName);
            Result<PhoneNumber> phoneNumber = PhoneNumber.Create(dto.PhoneNumber);
            Result<Gender> gender = Gender.Create(dto.Gender);
            Result<WebsiteAddress> websiteAddress = WebsiteAddress.Create(dto.WebsiteAddress);
            Result<Bio> bio = Bio.Create(dto.Bio);
            Result<Password> password = Password.Create(dto.Password);

            Result result = Result.Combine(username, emailAddress, firstName, lastName, phoneNumber, gender, websiteAddress, bio, password);
            if (result.IsFailure) return BadRequest();

            Result registrationResult = await userService.CreateRegistrationAsync(Core.Model.RegisteredUser
                               .Create(id,
                                  username.Value,
                                  emailAddress.Value,
                                  firstName.Value,
                                  lastName.Value,
                                  dto.DateOfBirth,
                                  phoneNumber.Value,
                                  gender.Value,
                                  websiteAddress.Value,
                                  bio.Value,
                                  dto.IsPrivate,
                                  dto.IsAcceptingMessages,
                                  dto.IsAcceptingTags,
                                  password.Value,
                                  ProfileImagePath.Create("").Value,
                                  new List<Core.Model.RegisteredUser>(),
                                  new List<Core.Model.RegisteredUser>(),
                                  new List<Core.Model.RegisteredUser>(),
                                  new List<Core.Model.RegisteredUser>(),
                                  new List<Core.Model.RegisteredUser>(),
                                  new List<Core.Model.RegisteredUser>(),
                                  new List<Core.Model.RegisteredUser>(),
                                  new List<Core.Model.RegisteredUser>(),
                                  false).Value);

            if (registrationResult.IsFailure) return BadRequest();
            dto.Id = id;
            return Ok(/*this.Request.Path + id, ""*/ dto);
        }

        [HttpPost("login")]
        public IActionResult Login(UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = userService.FindUser(login.Username, login.Password);
            if (user != null)
            {
                var tokenString = userService.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        [HttpGet("{idUser}")]
        public IActionResult GetById(Guid idUser)
        {
            Core.Model.RegisteredUser user = userService.GetUserById(idUser);
            if (user == null) return BadRequest();
            return Ok(registerUserFactory.Create(user));
        }

        [HttpGet("{loggedId}/logged/{userId}/user")]
        public IActionResult GetByIdWithoutBlocked([FromRoute] Guid loggedId, [FromRoute] Guid userId)
        {
            Core.Model.RegisteredUser user = userService.GetUserByIdWithoutBlocked(loggedId, userId);
            if (user == null) return BadRequest();
            return Ok(registerUserFactory.Create(user));
        }

        [HttpPut("edit")]
        public IActionResult Edit(DTOs.RegisteredUser dto)
        {
            Result<Username> username = Username.Create(dto.Username);
            Result<EmailAddress> emailAddress = EmailAddress.Create(dto.EmailAddress);
            Result<FirstName> firstName = FirstName.Create(dto.FirstName);
            Result<LastName> lastName = LastName.Create(dto.LastName);
            Result<PhoneNumber> phoneNumber = PhoneNumber.Create(dto.PhoneNumber);
            Result<Gender> gender = Gender.Create(dto.Gender);
            Result<WebsiteAddress> websiteAddress = WebsiteAddress.Create(dto.WebsiteAddress);
            Result<Bio> bio = Bio.Create(dto.Bio);
            Result<Password> password = Password.Create("password");

            Result result = Result.Combine(username, emailAddress, firstName, lastName, phoneNumber, gender, websiteAddress, bio, password);
            if (result.IsFailure) return BadRequest(result.Error);
            if (!_userRepository.GetById(dto.Id).Value.Username.ToString().Equals(dto.Username))
            {
                if (_userRepository.GetByUsername(dto.Username).HasValue) return BadRequest();
            }
            return Ok(userService.Edit((Core.Model.RegisteredUser.Create(dto.Id,
                                          username.Value,
                                          emailAddress.Value,
                                          firstName.Value,
                                          lastName.Value,
                                          dto.DateOfBirth,
                                          phoneNumber.Value,
                                          gender.Value,
                                          websiteAddress.Value,
                                          bio.Value,
                                          dto.IsPrivate,
                                          dto.IsAcceptingMessages,
                                          dto.IsAcceptingTags,
                                          password.Value,
                                          ProfileImagePath.Create("").Value,
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          new List<Core.Model.RegisteredUser>(),
                                          dto.IsBanned).Value)));
        }

        [HttpGet]
        public IActionResult Search([FromQuery] Guid id, [FromQuery] string name, [FromQuery] string access)
        {
            if (Request.Query.Count == 0) return BadRequest();
            if (id == Guid.Empty && String.IsNullOrWhiteSpace(name) && String.IsNullOrEmpty(access)) return BadRequest();
            return Ok(_userRepository.GetBy(name, access)
                .Select(user => registerUserFactory.Create(user)));
        }

        [HttpPost("follow")]
        public IActionResult Follow(Follow follow)
        {
            Guid id = Guid.NewGuid();
            if (userService.Follow(id, follow.FollowedById, follow.FollowingId).IsFailure) return BadRequest();
            return Created(this.Request.Path + id, "");
        }

        [HttpPost("followprivate")]
        public IActionResult FollowPrivate(Follow follow)
        {
            Guid id = Guid.NewGuid();
            _userRepository.Follow(id, follow.FollowedById, follow.FollowingId);
            return Created(this.Request.Path + id, "");
        }

        [HttpPut("handlerequest")]
        public IActionResult HandleFollowRequest(Follow follow)
        {
            Guid newId = Guid.NewGuid();
            userService.HandleFollowRequest(follow.Id, follow.FollowedById, follow.FollowingId, follow.Type, follow.IsApproved, newId);
            return Ok();
        }

        [HttpGet("{userId}/followRequests")]
        public IActionResult GetFollowRequests(Guid userId)
        {
            return Ok(_userRepository.GetFollowRequestsForUser(userId)
               .Select(followRequest => followRequestFactory.Create(followRequest)));
        }

        [HttpGet("{userId}/following")]
        public IActionResult GetFollowers(Guid userId)
        {
            return Ok(_userRepository.GetFollowing(userId)
               .Select(follower => registerUserFactory.Create(follower)));
        }

        [HttpGet("contents/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            if (fileName.Equals(""))
            {
                return Ok();
            }
            FileContentResult fileContentResult = File(userService.GetImage(_env.WebRootPath, fileName),
                "image/jpeg");
            return Ok(fileContentResult);
        }

        [HttpPost("contents")]
        public IActionResult SaveImg([FromForm] FileModel file)
        {
            string fileName = userService.ImageToSave(_env.WebRootPath, file);

            return Ok(fileName);
        }

        [HttpPut("{id}/profile-picture/{image}")]
        public IActionResult AddProfilePicture([FromRoute] Guid id, [FromRoute] string image)
        {
            _userRepository.AddProfilePicture(id, image);
            return Ok();
        }

        [HttpPut("{userId}/close-friends/{closeFriendId}")]
        public IActionResult AddCloseFriend([FromRoute] string userId, [FromRoute] string closeFriendId)
        {
            if (userService.AddCloseFriend(Guid.NewGuid(), new Guid(userId), new Guid(closeFriendId)).IsFailure) return BadRequest();
            return NoContent();
        }

        [HttpPost("mute")]
        public IActionResult Mute(Mute mute)
        {
            Guid id = Guid.NewGuid();
            if (userService.Mute(id, mute.MutedById, mute.MutingId).IsFailure) return BadRequest();
            return Created(this.Request.Path + id, "");
        }

        [HttpGet("{userId}/following-without-muted")]
        public IActionResult GetFollowersWithoutMuted(Guid userId)
        {
            return Ok(_userRepository.GetFollowingWithoutMuted(userId)
               .Select(follower => registerUserFactory.Create(follower)));
        }

        [HttpPost("block")]
        public IActionResult Block(Block block)
        {
            Guid id = Guid.NewGuid();
            if (userService.Block(id, block.BlockedById, block.BlockingId).IsFailure) return BadRequest();
            return Created(this.Request.Path + id, "");
        }

        [HttpPut("{id}/ban")]
        public IActionResult BanUser(Guid id)
        {
            _userRepository.BanUser(id);
            return Ok();
        }
    }
}
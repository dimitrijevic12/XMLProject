﻿using CSharpFunctionalExtensions;
using EasyNetQ;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.Contracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserMicroservice.Core.Interface.Repository;
using UserMicroservice.Core.Interface.Service;
using UserMicroservice.Core.Model;
using UserMicroservice.Core.Model.File;

namespace UserMicroservice.Core.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAdminRepository _adminRepository;
        private IConfiguration _config;
        private readonly IBus _bus;

        public UserService(IUserRepository userRepository, IAdminRepository adminRepository, IConfiguration config, IBus bus)
        {
            _userRepository = userRepository;
            _adminRepository = adminRepository;
            _config = config;
            _bus = bus;
        }

        public async Task<Result> CreateRegistrationAsync(RegisteredUser registeredUser)
        {
            var result = Create(registeredUser);
            if (result.IsFailure) return Result.Failure(result.Error);
            await _bus.PubSub.PublishAsync(new UserRegisteredEvent
            {
                Id = registeredUser.Id.ToString(),
                Username = registeredUser.Username,
                FirstName = registeredUser.FirstName,
                LastName = registeredUser.LastName,
                ProfilePicturePath = registeredUser.ProfileImagePath,
                IsPrivate = registeredUser.IsPrivate,
                IsAcceptingTags = registeredUser.IsAcceptingTags,
                Followers = CreateIds(registeredUser.Followers),
                Following = CreateIds(registeredUser.Following)
            });
            return Result.Success(registeredUser);
        }

        public List<string> CreateIds(IEnumerable<Core.Model.RegisteredUser> registeredUsers)
        {
            var test = registeredUsers.Select(registeredUser => registeredUser.Id.ToString()).ToList();
            return test;
        }

        private Result Create(RegisteredUser registeredUser)
        {
            if (_userRepository.GetById(registeredUser.Id).HasValue) return Result.Failure("User with that id already exist");
            if (_userRepository.GetByUsername(registeredUser.Username).HasValue) return Result.Failure("User with that username already exist");
            _userRepository.Save(registeredUser);
            return Result.Success(registeredUser);
        }

        public Task CompleteRegistrationAsync(Guid registeredUserId)
        {
            return Task.CompletedTask;
        }

        public Task RejectRegistrationAsync(Guid registeredUserId, string reason)
        {
            _userRepository.Delete(registeredUserId);

            return Task.CompletedTask;
        }

        public Result Edit(RegisteredUser registeredUser)
        {
            _userRepository.Edit(registeredUser);
            return Result.Success(registeredUser);
        }

        public Result EditVerifiedUser(VerifiedUser verifiedUser)
        {
            _userRepository.EditVerifiedUser(verifiedUser);
            return Result.Success(verifiedUser);
        }

        public RegisteredUser GetUserById(Guid id)
        {
            if (_userRepository.GetById(id).HasNoValue) return null;
            return _userRepository.GetById(id).Value;
        }

        public RegisteredUser GetUserByIdWithoutBlocked(Guid loggedId, Guid userId)
        {
            if (_userRepository.GetByIdWithoutBlocked(loggedId, userId).HasNoValue) return null;
            return _userRepository.GetByIdWithoutBlocked(loggedId, userId).Value;
        }

        public User FindUser(String username, String password)
        {
            var admin = _adminRepository.GetByUsername(username);
            if (admin.HasValue && admin.Value.Password.ToString().Equals(password))
            {
                return _adminRepository.GetByUsername(username).Value;
            }
            var user = _userRepository.GetByUsername(username);
            if (user.HasNoValue || !user.Value.Password.ToString().Equals(password)) return null;
            return _userRepository.GetRoleByUsername(username).Value;
        }

        public string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("user_id", userInfo.Id.ToString()),
                new Claim("username", userInfo.Username),
                new Claim("role", userInfo.GetType().Name),
                new Claim (ClaimTypes.Role, userInfo.GetType().Name)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public RegisteredUser Delete(RegisteredUser obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegisteredUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public RegisteredUser Save(RegisteredUser obj)
        {
            throw new NotImplementedException();
        }

        public Result Follow(Guid id, Guid followedById, Guid followingId)
        {
            if ((_userRepository.GetById(followedById).HasNoValue) || (_userRepository.GetById(followingId).HasNoValue)) return Result.Failure("There is no user with that id");
            if (_userRepository.GetById(followingId).Value.IsPrivate)
            {
                if (_userRepository.AlreadyFollowingPrivate(followedById, followingId)) return Result.Failure("Request is already sent or you are already following this account");
                _userRepository.FollowPrivate(id, followedById, followingId);
                return Result.Success();
            }
            if (_userRepository.AlreadyFollowing(followedById, followingId)) return Result.Failure("They are already following");
            _userRepository.Follow(id, followedById, followingId);
            return Result.Success();
        }

        public Result HandleFollowRequest(Guid id, Guid followedById, Guid followingId, String type, Boolean is_approved, Guid newId)
        {
            _userRepository.HandleFollowRequest(id, type, is_approved);
            if (is_approved && type == "approve")
            {
                _userRepository.Follow(newId, followedById, followingId);
                return Result.Success();
            }
            return Result.Success();
        }

        public byte[] GetImage(string path, string fileName)
        {
            path = path + "/images/" + fileName;
            return File.ReadAllBytes(path);
        }

        public string ImageToSave(string path, FileModel file)
        {
            try
            {
                using (Stream stream = new FileStream(path + "/images/" + file.FileName, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }
                return file.FileName;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Result AddCloseFriend(Guid id, Guid userId, Guid closeFriendId)
        {
            var user = _userRepository.GetById(userId);
            var closeFriend = _userRepository.GetById(closeFriendId);
            if ((user.HasNoValue) || (closeFriend.HasNoValue)) return Result.Failure("There is no user with that id");
            if (user.Value.MyCloseFriends.Contains(closeFriend.Value)) return Result.Failure("User is already a close friend");
            _userRepository.AddCloseFriend(id, userId, closeFriendId);
            return Result.Success("User successfully added to close friends");
        }

        public Result Mute(Guid id, Guid mutedById, Guid mutingId)
        {
            var user = _userRepository.GetById(mutedById);
            var mutedUser = _userRepository.GetById(mutingId);
            if ((user.HasNoValue) || (mutedUser.HasNoValue)) return Result.Failure("There is no user with that id");
            if (user.Value.MutedUsers.Contains(mutedUser.Value)) return Result.Failure("User is already a muted");
            _userRepository.Mute(id, mutedById, mutingId);
            return Result.Success("User is successfully muted");
        }

        public Result Block(Guid id, Guid blockedById, Guid blockingId)
        {
            var user = _userRepository.GetById(blockedById);
            var blockedUser = _userRepository.GetById(blockingId);
            if ((user.HasNoValue) || (blockedUser.HasNoValue)) return Result.Failure("There is no user with that id");
            if (user.Value.BlockedUsers.Contains(blockedUser.Value)) return Result.Failure("User is already a blocked");
            _userRepository.Block(id, blockedById, blockingId);
            _userRepository.DeleteFollows(blockedById, blockingId);
            _userRepository.DeleteFollowRequests(blockedById, blockingId);
            return Result.Success("User is successfully blocked");
        }
    }
}
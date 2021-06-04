using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserMicroservice.Core.Interface.Repository;
using UserMicroservice.Core.Interface.Service;
using UserMicroservice.Core.Model;

namespace UserMicroservice.Core.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAdminRepository _adminRepository;
        private IConfiguration _config;

        public UserService(IUserRepository userRepository, IAdminRepository adminRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _adminRepository = adminRepository;
            _config = config;
        }

        public Result Create(RegisteredUser registeredUser)
        {
            if (_userRepository.GetById(registeredUser.Id).HasValue) return Result.Failure("User with that id already exist");
            if (_userRepository.GetByUsername(registeredUser.Username).HasValue) return Result.Failure("User with that username already exist");
            _userRepository.Save(registeredUser);
            return Result.Success(registeredUser);
        }

        public Result Edit(RegisteredUser registeredUser)
        {
            _userRepository.Edit(registeredUser);
            return Result.Success(registeredUser);
        }

        public RegisteredUser GetUserById(Guid id)
        {
            if (_userRepository.GetById(id).HasNoValue) return null;
            return _userRepository.GetById(id).Value;
        }

        public User FindUser(String username, String password)
        {
            if (_adminRepository.GetByUsername(username).HasValue)
            {
                return _adminRepository.GetByUsername(username).Value;
            }
            if (_userRepository.GetByUsername(username).HasNoValue) return null;
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

        public RegisteredUser GetById(int id)
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
            if (is_approved && type == "approv")
            {
                _userRepository.Follow(newId, followedById, followingId);
                return Result.Success();
            }
            return Result.Success();
        }
    }
}
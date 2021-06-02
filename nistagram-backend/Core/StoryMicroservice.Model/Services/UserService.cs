using CSharpFunctionalExtensions;
using StoryMicroservice.Core.Interface.Repository;
using StoryMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryMicroservice.Core.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Result Create(RegisteredUser registeredUser)
        {
            _userRepository.Save(registeredUser);
            return Result.Success(registeredUser);
        }
    }
}
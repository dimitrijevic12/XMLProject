using CSharpFunctionalExtensions;
using PostMicroservice.Core.Interface.Repository;
using PostMicroservice.Core.Model;
using System;
using System.Collections.Generic;

namespace PostMicroservice.Core.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public RegisteredUser GetById(Guid id)
        {
            return _userRepository.GetById(id);
        }

        public IEnumerable<RegisteredUser> GetTaggable()
        {
            return _userRepository.GetTaggable();
        }

        public Result Create(RegisteredUser registeredUser)
        {
            _userRepository.Save(registeredUser);
            return Result.Success(registeredUser);
        }

        public Result Edit(RegisteredUser registeredUser)
        {
            _userRepository.Edit(registeredUser);
            return Result.Success(registeredUser);
        }
    }
}
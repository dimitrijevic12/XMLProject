using PostMicroservice.Core.Interface.Repository;
using PostMicroservice.Core.Model;
using System;

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
    }
}
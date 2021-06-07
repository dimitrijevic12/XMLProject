using CSharpFunctionalExtensions;
using PostMicroservice.Core.Interface.Repository;
using PostMicroservice.Core.Model;
using PostMicroservice.Core.Model.File;
using System;
using System.Collections.Generic;
using System.IO;

namespace PostMicroservice.Core.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICollectionRepository _collectionRepository;

        public UserService(IUserRepository userRepository, ICollectionRepository collectionRepository)
        {
            _userRepository = userRepository;
            _collectionRepository = collectionRepository;
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
            _collectionRepository.Save(Collection.Create(Guid.NewGuid(), CollectionName.Create("favourites").Value,
                new List<Post>(), registeredUser).Value);
            return Result.Success(registeredUser);
        }

        public Result Edit(RegisteredUser registeredUser)
        {
            _userRepository.Edit(registeredUser);
            return Result.Success(registeredUser);
        }

        public void AddProfilePicture(Guid id, string image)
        {
            _userRepository.AddProfilePicture(id, image);
        }
    }
}
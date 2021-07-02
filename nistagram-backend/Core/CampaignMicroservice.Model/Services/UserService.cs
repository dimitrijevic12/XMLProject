using CampaignMicroservice.Core.Interface;
using CSharpFunctionalExtensions;
using EasyNetQ;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CampaignMicroservice.Core.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private IConfiguration _config;
        private readonly IBus _bus;

        public UserService(IUserRepository userRepository, IConfiguration config, IBus bus)
        {
            _userRepository = userRepository;
            _config = config;
            _bus = bus;
        }

        public async Task<Result> FollowAsync(Guid id, Guid followedById, Guid followingId)
        {
            var result = Follow(id, followedById, followingId);
            if (result.IsFailure) return Result.Failure(result.Error);
            return Result.Success();
        }

        public Task RejectFollowAsync(Guid followedById, Guid followingId, string reson)
        {
            _userRepository.DeleteFollow(followedById, followingId);

            return Task.CompletedTask;
        }

        public Result Follow(Guid id, Guid followedById, Guid followingId)
        {
            if (_userRepository.AlreadyFollowing(followedById, followingId)) return Result.Failure("They are already following");
            _userRepository.Follow(id, followedById, followingId);
            return Result.Success();
        }
    }
}
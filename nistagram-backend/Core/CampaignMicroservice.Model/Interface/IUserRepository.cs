using CampaignMicroservice.Core.Model;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignMicroservice.Core.Interface
{
    public interface IUserRepository : IRepository<RegisteredUser>
    {
        public Maybe<RegisteredUser> GetByUsername(String username);

        public void Follow(Guid id, Guid followedById, Guid followingId);

        public void DeleteFollow(Guid followedById, Guid followingId);

        public Boolean AlreadyFollowing(Guid requests_follow_id, Guid recieves_follow_id);

        public void Mute(Guid id, Guid mutedById, Guid mutingId);

        public void Block(Guid id, Guid blockedById, Guid blockingId);

        public void DeleteBlock(Guid id);

        public void DeleteFollows(Guid blockedById, Guid blockingId);
    }
}
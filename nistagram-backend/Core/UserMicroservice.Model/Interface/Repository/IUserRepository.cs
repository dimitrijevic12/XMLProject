using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroservice.Core.Model;

namespace UserMicroservice.Core.Interface.Repository
{
    public interface IUserRepository : IRepository<RegisteredUser>
    {
        public Maybe<RegisteredUser> GetByUsername(String username);

        public Maybe<User> GetRoleByUsername(String username);

        public IEnumerable<RegisteredUser> GetBy(string name, string access);

        public void Follow(Guid id, Guid followedById, Guid followingId);

        public void FollowPrivate(Guid id, Guid followedById, Guid followingId);

        public Boolean AlreadyFollowing(Guid requests_follow_id, Guid recieves_follow_id);

        public Boolean AlreadyFollowingPrivate(Guid requests_follow_id, Guid recieves_follow_id);

        public void HandleFollowRequest(Guid id, String type, Boolean is_approved);

        public IEnumerable<FollowRequest> GetFollowRequestsForUser(Guid id);
    }
}
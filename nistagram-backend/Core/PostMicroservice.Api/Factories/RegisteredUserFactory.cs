using PostMicroservice.Api.DTOs;

namespace PostMicroservice.Api.Factories
{
    public class RegisteredUserFactory
    {
        public RegisteredUser Create(Core.Model.RegisteredUser registeredUser)
        {
            return new RegisteredUser
            {
                Id = registeredUser.Id,
                Username = registeredUser.Username,
                FirstName = registeredUser.FirstName,
                LastName = registeredUser.LastName,
                ProfileImagePath = registeredUser.ProfileImagePath
            };
        }
    }
}
using NotificationMicroservice.Api.DTOs;

namespace NotificationMicroservice.Api.Factories
{
    public class RegisteredUserFactory
    {
        private readonly NotificationOptionsFactory notificationOptionsFactory;

        public RegisteredUserFactory(NotificationOptionsFactory notificationOptionsFactory)
        {
            this.notificationOptionsFactory = notificationOptionsFactory;
        }

        public RegisteredUser Create(Core.Model.RegisteredUser registeredUser)
        {
            return new RegisteredUser
            {
                Id = registeredUser.Id,
                Username = registeredUser.Username,
                NotificationOptions = notificationOptionsFactory.Create(registeredUser.NotificationOptions),
                ProfilePicturePath = registeredUser.ProfilePicturePath
            };
        }
    }
}
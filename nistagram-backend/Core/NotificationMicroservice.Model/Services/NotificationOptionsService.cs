using NotificationMicroservice.Core.Interface.Repository;
using NotificationMicroservice.Core.Model;
using System;

namespace NotificationMicroservice.Core.Services
{
    public class NotificationOptionsService
    {
        private readonly INotificationOptionsRepository _notificationOptionsRepository;
        private readonly IRegisteredUserRepository _registeredUserRepository;

        public NotificationOptionsService(INotificationOptionsRepository notificationOptionsRepository,
            IRegisteredUserRepository registeredUserRepository)
        {
            _notificationOptionsRepository = notificationOptionsRepository;
            _registeredUserRepository = registeredUserRepository;
        }

        public NotificationOptions GetBy(Guid loggedUserId, Guid notificationByUserId)
        {
            if (_notificationOptionsRepository.GetBy(loggedUserId, notificationByUserId).HasNoValue)
            {
                NotificationOptions notificationOptions = NotificationOptions.Create(Guid.NewGuid(), false,
                    false, false, false, false, _registeredUserRepository.GetById(loggedUserId).Value,
                    _registeredUserRepository.GetById(notificationByUserId).Value).Value;
                return _notificationOptionsRepository.Save(notificationOptions);
            }
            else
            {
                return _notificationOptionsRepository.GetBy(loggedUserId, notificationByUserId).Value;
            }
        }
    }
}
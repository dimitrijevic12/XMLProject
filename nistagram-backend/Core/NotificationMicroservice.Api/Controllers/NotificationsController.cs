using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Api.Factories;
using NotificationMicroservice.Core.Interface.Repository;
using NotificationMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotificationMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IRegisteredUserRepository _registeredUserRepository;
        private readonly NotificationFactory notificationFactory;

        public NotificationsController(INotificationRepository notificationRepository,
            NotificationFactory notificationFactory, IRegisteredUserRepository registeredUserRepository)
        {
            _notificationRepository = notificationRepository;
            _registeredUserRepository = registeredUserRepository;
            this.notificationFactory = notificationFactory;
        }

        [HttpPost]
        public IActionResult Save(DTOs.Notification notification)
        {
            Result<DateTime> timeStamp = DateTime.Now;
            Result result = Result.Combine(timeStamp);
            if (result.IsFailure) return BadRequest();
            RegisteredUser registeredUser = _registeredUserRepository.GetById(notification.RegisteredUser.Id).Value;
            Guid id = Guid.NewGuid();
            if (notification.Type.Equals("Post"))
            {
                Post post = Post.Create(notification.ContentId).Value;
                if (_notificationRepository.Save(Notification.Create(id, timeStamp.Value, post, registeredUser).Value) == null)
                    return BadRequest();
            }
            else if (notification.Type.Equals("Story"))
            {
                Story story = Story.Create(notification.ContentId).Value;
                if (_notificationRepository.Save(Notification.Create(id, timeStamp.Value, story, registeredUser).Value) == null)
                    return BadRequest();
            }
            else if (notification.Type.Equals("Comment"))
            {
                Comment comment = Comment.Create(notification.ContentId).Value;
                if (_notificationRepository.Save(Notification.Create(id, timeStamp.Value, comment, registeredUser).Value) == null)
                    return BadRequest();
            }
            else if (notification.Type.Equals("FollowRequest"))
            {
                FollowRequest followRequest = FollowRequest.Create(notification.ContentId).Value;
                if (_notificationRepository.Save(Notification.Create(id, timeStamp.Value, followRequest, registeredUser).Value) == null)
                    return BadRequest();
            }
            else
            {
                Message message = Message.Create(notification.ContentId).Value;
                if (_notificationRepository.Save(Notification.Create(id, timeStamp.Value, message, registeredUser).Value) == null)
                    return BadRequest();
            }

            return Created(this.Request.Path + "/" + id, "");
        }

        [HttpPost("following")]
        public IActionResult GetNotificationsForFollowing(DTOs.NotificationUsers notificationUsers)
        {
            List<RegisteredUser> users = (notificationUsers.RegisteredUsers.Select(registeredUser =>
                _registeredUserRepository.GetById(registeredUser.Id).Value)).ToList();
            RegisteredUser loggedUser = _registeredUserRepository.GetById(notificationUsers.LoggedUser.Id).Value;
            return Ok(notificationFactory.CreateNotifications(_notificationRepository.GetNotificationsForFollowing(users, loggedUser)));
        }
    }
}
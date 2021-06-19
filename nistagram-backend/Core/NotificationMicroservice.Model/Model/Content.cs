using System;

namespace NotificationMicroservice.Core.Model
{
    public abstract class Content
    {
        public Guid Id { get; }

        protected Content(Guid id)
        {
            Id = id;
        }
    }
}
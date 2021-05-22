using System;

namespace NotificationService.Core.Model
{
    public abstract class Content
    {
        protected readonly Guid id;

        protected Content(Guid id)
        {
            this.id = id;
        }
    }
}
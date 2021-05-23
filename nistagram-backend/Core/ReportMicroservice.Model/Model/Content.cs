using System;

namespace ReportMicroservice.Core.Model
{
    public abstract class Content
    {
        private readonly Guid id;

        public Content(Guid id)
        {
            this.id = id;
        }
    }
}
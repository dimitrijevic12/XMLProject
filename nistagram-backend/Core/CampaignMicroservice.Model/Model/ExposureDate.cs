using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignMicroservice.Core.Model
{
    public class ExposureDate : ValueObject
    {
        public DateTime Time { get; }
        public IEnumerable<RegisteredUser> SeenBy { get; }

        private ExposureDate(DateTime time, IEnumerable<RegisteredUser> seenBy)
        {
            Time = time;
            SeenBy = seenBy;
        }

        public static Result<ExposureDate> Create(DateTime time, IEnumerable<RegisteredUser> seenBy)
        {
            return new ExposureDate(time, seenBy);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Time;
            yield return SeenBy;
        }
    }
}
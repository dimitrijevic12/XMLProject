using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignMicroservice.Api.DTOs
{
    public class Campaign
    {
        public Guid Id { get; set; }
        public TargetAudience targetAudience { get; set; }
        public Guid AgentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateOfChange { get; set; }
        public IEnumerable<ExposureDate> ExposureDates { get; set; }
        public IEnumerable<Ad> Ads { get; set; }
    }
}
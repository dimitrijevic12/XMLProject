using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using ReportMicroservice.Core.Interface.Repository;
using ReportMicroservice.Core.Model;
using System;

namespace ReportMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;

        public ReportsController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [HttpPost]
        public IActionResult Save(DTOs.Report report)
        {
            Result<DateTime> timeStamp = DateTime.Now;
            Result<ReportReason> reportReason = ReportReason.Create(report.ReportReason);
            Result result = Result.Combine(timeStamp, reportReason);
            if (result.IsFailure) return BadRequest();
            RegisteredUser registeredUser = RegisteredUser.Create(report.RegisteredUser.Id,
                Username.Create(report.RegisteredUser.Username).Value).Value;

            Guid id = Guid.NewGuid();
            if (report.Type.Equals("post"))
            {
                Post post = Post.Create(report.Content.Id).Value;
                if (_reportRepository.Save(Report.Create(id, timeStamp.Value, reportReason.Value, registeredUser, post).Value) == null) return BadRequest();
                return Created(this.Request.Path + "/" + id, "");
            }
            else
            {
                Story story = Story.Create(report.Content.Id).Value;
                if (_reportRepository.Save(Report.Create(id, timeStamp.Value, reportReason.Value, registeredUser, story).Value) == null) return BadRequest();
                return Created(this.Request.Path + "/" + id, "");
            }
        }
    }
}
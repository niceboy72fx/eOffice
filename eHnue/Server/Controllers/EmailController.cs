using eHnue.Server.Services;
using eHnue.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHnue.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        IEmailService _emailService = null;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [Route("SendEmail")]
        [HttpPost]
        public bool SendEmail(EmailData emailData)
        {
            return _emailService.SendEmail(emailData);
        }

        [Route("SendEmailWithAttachment")]
        [HttpPost]
        public bool SendEmailWithAttachment([FromForm] EmailDataWithAttachment emailData)
        {
            return _emailService.SendEmailWithAttachment(emailData);
        }

        [Route("SendUserWelcomeEmail")]
        [HttpPost]
        public bool SendUserWelcomeEmail([FromForm] UserData userData)
        {
            return _emailService.SendUserWelcomeEmail(userData);
        }
    }
}
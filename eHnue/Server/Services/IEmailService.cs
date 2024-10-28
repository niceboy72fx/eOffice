using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eHnue.Shared.Models;

namespace eHnue.Server.Services
{
    public interface IEmailService
    {
        bool SendEmail(EmailData emailData);
        bool SendEmailWithAttachment(EmailDataWithAttachment emailData);
        bool SendUserWelcomeEmail(UserData userData);
    }
}

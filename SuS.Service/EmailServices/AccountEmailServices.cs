using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using SuS.Data.Models;

namespace SuS.Service.EmailServices
{
    public class AccountEmailServices
    {
        SmtpClient smtpClient;
        NetworkCredential networkCredentials;

        public AccountEmailServices()
        {

        }

        public bool SendVerifyEmail(ApplicationUser user, string emailAddress)
        {
            try
            {
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Please verify your email for SuS Selector";
                message.Body = "Thank you for signing up for SuS Selector.\n\n" +
                    "Please verify your link by clicking this link: " +
                    string.Format("http://test-url.com/Account/VerifyEmail?UserId={0}" + user.Id) +
                    "\n\nThen you can start your first selection sheet by going to: " +
                    string.Format("http://test-url.com/Builders/Index") + 
                    "\n\nThank you!";
                smtpClient.Send(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

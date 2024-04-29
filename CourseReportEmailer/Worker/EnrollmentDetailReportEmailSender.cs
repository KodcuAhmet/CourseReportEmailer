using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CourseReportEmailer.Worker
{
    class EnrollmentDetailReportEmailSender
    {
        public void Send(string fileName)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            NetworkCredential creds = new NetworkCredential("mark.twain@email.com", "password");
            client.EnableSsl = true;
            client.Credentials = creds;

            MailMessage message = new MailMessage("mark.twain@email.com", "twain.mark@email.com");
            message.Subject = "Enrollment Details Report";
            message.IsBodyHtml = true;
            message.Body = "Hi, <br><br>Attached please find the enrolment details report<br><br>";

            Attachment attachment = new Attachment(fileName);
            message.Attachments.Add(attachment);
            client.Send(message);
        }
    }
}

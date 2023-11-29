using System;
using System.Net.Mail;
using System.Net;
using Modelos;

namespace Controladores
{
    public class Gmail
    {
        SmtpClient SmtpServer;
        public bool sendEmail(GmailModel gmailModel,string path)
        {
            try
            {
                stablishConnection();
                MailMessage email = new MailMessage();
                Attachment pdf = new Attachment(path);
                email.Attachments.Add(pdf);
                email.From = new MailAddress(gmailModel.from);
                email.To.Add(gmailModel.to);
                email.Subject = gmailModel.subject;
                email.Body = gmailModel.body;
                SmtpServer.Credentials = new NetworkCredential(gmailModel.from, "keyrxjxuosgtjdbg");
                SmtpServer.Send(email);
            }
            catch (Exception ex)
            {

            }
            return true;
        }
        public bool stablishConnection()
        {
            try
            {
                SmtpServer = new SmtpClient("smtp.gmail.com", 587); //  587
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Timeout = 5000;
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;

                return true;
            }
            catch { return false; }
        }
    }
}
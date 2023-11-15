using System;
using System.Net.Mail;
using System.Net;
using Modelos;

namespace Controladores
{
    public class Gmail
    {
        SmtpClient SmtpServer;
        public bool sendEmail(GmailModel gmailModel)
        {
            try
            {
                stablishConnection();
                MailMessage email = new MailMessage();
                email.From = new MailAddress(gmailModel.from);
                email.To.Add(gmailModel.to);
                email.Subject = gmailModel.subject;
                email.Body = gmailModel.body;

                SmtpServer.Credentials = new NetworkCredential(gmailModel.from, "fytkiskqpifjnpzi");
                SmtpServer.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool stablishConnection()
        {
            SmtpServer = new SmtpClient("smtp.gmail.com", 587);
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.Timeout = 5000;
            SmtpServer.EnableSsl = true;
            SmtpServer.UseDefaultCredentials = false;

            return true;
        }
    }
}
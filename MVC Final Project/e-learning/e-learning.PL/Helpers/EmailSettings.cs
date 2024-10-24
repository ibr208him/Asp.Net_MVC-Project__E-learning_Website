using e_learning.DAL.Models;
using System.Net;
using System.Net.Mail;

namespace e_learning.PL.Helpers
{
    public class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587); // server is gmail servr and port number is 587
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("ibra208him@gmail.com", "bhro fjtn tqcc deby");
            //client.Send("ibra208him@gmail.com", email.Receivers, email.Subject, email.Body);
            var mailMessage = new MailMessage("ibra208him@gmail.com", email.Receivers, email.Subject, email.Body);
            client.Send(mailMessage);

        }
    

    //public static void SendEmail(Email email)
    //{
    //    try
    //    {
    //        var client = new SmtpClient("smtp.gmail.com", 587); // Try using port 465 (SSL)
    //        client.EnableSsl = true;
    //        client.UseDefaultCredentials = false;
    //        client.Credentials = new NetworkCredential("ibra208him@gmail.com", "bhro fjtn tqcc deby");
    //        client.DeliveryMethod = SmtpDeliveryMethod.Network;

    //        var mailMessage = new MailMessage("ibra208him@gmail.com", email.Receivers, email.Subject, email.Body);
    //        client.Send(mailMessage);
    //    }
    //    catch (SmtpException ex)
    //    {
    //        // Log detailed exception messages
    //        Console.WriteLine($"SMTP Error: {ex.StatusCode} - {ex.Message}");
    //        throw; // Re-throw the exception after logging
    //    }
    //}
}
}


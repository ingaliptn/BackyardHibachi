using System.Net;
using System.Net.Mail;
using BackyardHibachi.Models;
using Microsoft.AspNetCore.Mvc;


namespace BackyardHibachi.Controllers
{
    public class MailController : Controller
    {
        [HttpPost]
        public IActionResult ProcessForm(Contact cu, LogicModel l)
        {
            if (ModelState.IsValid)
            {
                string body = ConstructBodyFromContact(cu);
                using (var client = new SmtpClient())
                {
                    client.Host = l.Smtp; // Your SMTP server (e.g., Gmail)
                    client.Port = l.Port; // SMTP Port (Gmail uses 587)
                    //client.EnableSsl = true;
                    //client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(l.Login, l.Password);
                    var message = new MailMessage();
                    message.From = new MailAddress(l.FromEmail, l.FromName); // Your email address
                    string[] toEmails = l.ToEmail.Split(',');
                    foreach (string email in toEmails)
                    {
                        message.To.Add(email.Trim());
                    }
                    message.Subject = l.Subject; // Email subject
                    message.IsBodyHtml = true;
                    message.Body = body;

                    client.Send(message);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }

            return RedirectToAction("Index", "Home");
        }

        private string ConstructBodyFromContact(Contact cu)
        {
            return $"Name: {cu.Name}<br>" +
            $"Phone: {cu.Phone}<br>" +
            $"Email: {cu.Email}<br>" +
            $"Company: {cu.Company}<br>" +
            $"Message: {cu.Message}<br>";
        }
    }
}


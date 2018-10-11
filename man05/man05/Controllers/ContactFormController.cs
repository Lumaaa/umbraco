using man05.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace man05.Controllers
{
    public class ContactFormController : SurfaceController
    {
        public ActionResult Index()
        {
            return PartialView("contactForms", new ContactForm());
        }
        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {
            
            //if (!ModelState.IsValid)
            //{
            //    try {
                var body = "<p>Email from" + model.Email + "<br />" + model.Name + "<br />" + "besked: " + model.Message + "</p>";
                var message = new MailMessage();

                message.To.Add("*******e@gmail.com");               
                message.From = new MailAddress(model.Email);
                message.Subject = model.subject;
                message.Body = model.Message + "\n my mail is: " + model.Email;
                message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        var credential = new System.Net.NetworkCredential("********@gmail.com", "*******");
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        smtp.EnableSsl = true;
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.Credentials = credential;
                        smtp.EnableSsl = true;
                        smtp.Send(message);

                        ViewBag.Status = "Email Sent Successfully.";
                  }
            //    }
            //    catch (Exception e)
            //    {
            //        ViewBag.Status = e;
            //    }
            //    return CurrentUmbracoPage();

            //}
         
     

            return RedirectToCurrentUmbracoPage();
        }
    }
}
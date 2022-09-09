using IYarles.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using AspNetCore.ReCaptcha;
using System;

namespace IYarles.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult About()
        {
            return View();
        }

        // public IActionResult Services() // TODO: Find time to provide these, lol
        // {
        //     return View();
        // }

        public IActionResult Resume()
        {
            return RedirectToAction("PrettyResume");
        }

        public IActionResult AtsResume()
        {
            return View();
        }

        public IActionResult PrettyResume()
        {
            return View();
        }

        public IActionResult Contact() // TODO: Make it
        {
            return View();
        }

        [ValidateReCaptcha]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactEmail model) // TODO: Make it
        {
            // print email
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "The form values are invalid, please try again.";
                ViewBag.Status = "danger";
                return View();
            }

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("yarlescy@gmail.com", Environment.GetEnvironmentVariable("GOOGLE_APP_PASSWORD")),
                EnableSsl = true
            };
            client.Send("contact@iyarles.net", "yarlescy@gmail.com", $"Message from {model.Name} ({model.Email})", model.GenerateBody());

            ViewBag.Message = "Your message has been sent! I will get back to you as soon as possible.";
            ViewBag.Status = "primary";
            return View();
        }
    }
}
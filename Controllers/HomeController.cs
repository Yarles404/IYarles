using IYarles.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using IYarles.Secrets;

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
            return View();
        }

        public IActionResult Contact() // TODO: Make it
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactEmail model) // TODO: Make it
        {
            // print email
            Console.WriteLine($"Name: {model.Name}, Email: {model.Email}, Message: {model.Message}");
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "The form values are invalid, please try again.";
                ViewBag.Status = "danger";
                return View();
            }

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(Secrets.Secrets.YARLES_EMAIL, Secrets.Secrets.GOOGLE_APP_PASSWORD),
                EnableSsl = true
            };
            client.Send("contact@iyarles.net", "yarlescy@gmail.com", $"Message from {model.Name} ({model.Email})", model.GenerateBody());

            ViewBag.Message = "Your message has been sent! I will get back to you as soon as possible.";
            ViewBag.Status = "primary";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
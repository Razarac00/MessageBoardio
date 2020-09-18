using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MessageBoardio.MVC.Models;
using Microsoft.Extensions.Logging;

namespace MessageBoardio.MVC.Controllers
{
    public class HomeController : Controller
    {
        private MessageBoardModel m = MessageBoardModel.Instance;

        public List<string> getMessagesRaw()
        {
            return m.ListAll();
        }


        public HomeController()
        {
            // _logger = logger; //replace logging with the messageboardmodel. 
        }

        public IActionResult Index()
        {
            return View(m);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostMessage(string messageInput)
        {
            if (ModelState.IsValid)
            {
                MessageBoardModel.Instance.Add(messageInput); 
            }
            return RedirectToAction("Index", "Home");
        }
    }
}

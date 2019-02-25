using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotrubius.Models;
using dotrubius.Services;
using dotrubius.Utils;

namespace dotrubius.Controllers
{
    public class HomeController : Controller
    {
        private ContentFullService _contentFullService;
        public HomeController(ContentFullService contentFullService)
        {
            _contentFullService = contentFullService;
        }
        
        [Route("/")]
        [Route("/{page}")]
        public async Task<IActionResult> Index(string page)
        {
            ViewBag.Page = _contentFullService.GetContent(ContentType.CONTENT, page);
            return View();
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
    }
}

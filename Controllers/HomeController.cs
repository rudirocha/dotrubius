using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Contentful.Core;
using Contentful.Core.Search;
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
        
        public async Task<IActionResult> Index()
        {
            ViewBag.Page = _contentFullService.GetContent(ContentType.CONTENT);
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

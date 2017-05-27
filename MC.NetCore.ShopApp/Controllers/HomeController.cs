using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MC.NetCore.Repository;
using MC.NetCore.DomainModels;

namespace MC.NetCore.ShopApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOperationRepository _optRepository;
        public HomeController(IOperationRepository optRepository)
        {
            _optRepository = optRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

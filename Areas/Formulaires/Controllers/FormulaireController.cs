using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
// using myWebApp.Areas.Formulaires.Models;

namespace myWebApp.Areas.Formulaires.Controllers
{
    [Area("Formulaires")]
    public class FormulairesController : Controller
    {
        [Route("Formulaires")]
        [Route("Formulaires/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
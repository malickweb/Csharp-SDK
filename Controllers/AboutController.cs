using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace myWebApp.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Foo()
        {
            return View();
        }
    }
}
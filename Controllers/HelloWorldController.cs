using Microsoft.AspNetCore.Mvc;

namespace myWebApp.Controllers
{
    public class HelloWorldController : Controller
    {
        [Route("HelloWorld")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("HelloWorld/welcome")]
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
};
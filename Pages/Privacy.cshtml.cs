using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace myWebApp.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            GetExperiment();
        }
        public void GetExperiment()
        {
            string visitorCode = Startup.kameleoonClient.ObtainVisitorCode(Request, Response, "localhost:5000");
            // DO KAMELEOON STUFF
            Console.WriteLine($"VISITEUR CODE PRIVACY: {visitorCode}");
        }
    }
}

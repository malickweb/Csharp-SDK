using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Kameleoon;
using Newtonsoft.Json.Linq;

namespace myWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            GetExperiment();
        }
        public async void GetExperiment()
        {

            string VisitorCode = Startup.kameleoonClient.ObtainVisitorCode(Request, Response, "localhost:5000");
            // DO KAMELEOON STUFF

            int experimentID = 128989;
            Console.WriteLine($"VISITEUR CODE INDEX: {VisitorCode}");

            int recommendedProductsNumber = 0;

            try
            {
                int variationID;
                try
                {
                    variationID = await Startup.kameleoonClient.TriggerExperiment(VisitorCode, experimentID, 2000);
                    Console.WriteLine($"variationID: {variationID}");
                }
                catch (KameleoonException.NotTargeted e)
                {
                    Console.WriteLine($"KameleoonException.NotTargeted : {e}");
                    variationID = 0;
                }
                catch (KameleoonException.ExperimentConfigurationNotFound e)
                {
                    Console.WriteLine($"KameleoonException.ExperimentConfigurationNotFound : {e}");
                    variationID = 0;
                }

                if (variationID == 0)
                {
                    recommendedProductsNumber = 4;
                }
                else if (variationID == 558744)
                {
                    recommendedProductsNumber = 12;
                }
                else if (variationID == 558745)
                {
                    recommendedProductsNumber = 8;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($" e : {e}");
            }
            ViewData["KamRecoProduct"] = recommendedProductsNumber;
            Console.WriteLine($"recommendedProductsNumber : {recommendedProductsNumber}");
            Console.WriteLine($"experimentID : {experimentID}");

        }
    }
}
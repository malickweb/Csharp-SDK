using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kameleoon;

namespace myWebApp.Areas.KameleoonPerso
{
    public class KameleoonPerso : PageModel
    {
        // string VisitorCode = Startup.kameleoonClient.ObtainVisitorCode(Request, Response, "localhost:5000");
        // DO KAMELEOON STUFF
        public void OnGet()
        {
            GetExperiment();
        }
        public async void GetExperiment()
        {

            string VisitorCode = Startup.kameleoonClient.ObtainVisitorCode(Request, Response, "localhost:5000");
            // DO KAMELEOON STUFF

            int experimentID = 128989;
            Console.WriteLine($"VISITEUR CODE Product: {VisitorCode}");

            int recommendedProductsNumber = 0;

            try
            {
                int variationID;
                try
                {
                    variationID = await Startup.kameleoonClient.TriggerExperiment(VisitorCode, experimentID, 2000);
                    // JObject jsonObject = Startup.kameleoonClient.ObtainVariationAssociatedData(variationID);

                    // Console.WriteLine($"jsonObject: {jsonObject}");
                    Console.WriteLine($"variationID: {variationID}");
                }
                catch (KameleoonException.NotTargeted e)
                {
                    // The user did not trigger the experiment, as the associated targeting segment conditions were not fulfilled. He should see the reference variation
                    Console.WriteLine($"KameleoonException.NotTargeted : {e}");
                    variationID = 0;
                }
                catch (KameleoonException.ExperimentConfigurationNotFound e)
                {
                    // The user will not be counted into the experiment, but should see the reference variation
                    Console.WriteLine($"KameleoonException.ExperimentConfigurationNotFound : {e}");
                    variationID = 0;
                }

                if (variationID == 0)
                {
                    recommendedProductsNumber = 4;
                    //Console.WriteLine($"recommendedProductsNumber : {recommendedProductsNumber}");
                }
                else if (variationID == 558744)
                {
                    recommendedProductsNumber = 12;
                    //Console.WriteLine($"recommendedProductsNumber : {recommendedProductsNumber}");
                }
                else if (variationID == 558745)
                {
                    recommendedProductsNumber = 8;
                    //Console.WriteLine($"recommendedProductsNumber : {recommendedProductsNumber}");
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
        // public class Kproduct
        // {
        //     public string Name { get; set; }
        //     public double Price { get; set; }
        //     public string Link { get; set; }

        // }

    }
}
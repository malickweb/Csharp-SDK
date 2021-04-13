using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Kameleoon;
using myWebApp.Areas.Products.Models;
using myWebApp.Areas.KameleoonPerso;
namespace myWebApp.Areas.Products.Controllers
{
    [Area("Products")]
    public class ProductsController : Controller
    {
        public async void GetExperiment(int expeID)
        {

            string VisitorCode = Startup.kameleoonClient.ObtainVisitorCode(Request, Response, "localhost:5000");
            // DO KAMELEOON STUFF
            int experimentID = expeID;
            Console.WriteLine($"VISITEUR CODE Product: {VisitorCode}");

            int recommendedProductsNumber = 0;

            try
            {
                int variationID;
                try
                {
                    variationID = await Startup.kameleoonClient.TriggerExperiment(VisitorCode, experimentID, null);

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
        //[Route("Products")]
        [Route("Products/Index")]
        // [Area("Products")]
        public IActionResult Index()
        {
            //kam.GetExperiment();
            GetExperiment(128989);
            List<AreaProduct> ProductList = new List<AreaProduct>();
            {
                ProductList.Add(new AreaProduct(0, "PS5", 4999, "Console PS5", 2));
                ProductList.Add(new AreaProduct(1, "PS5", 499, "Console PS5", 10));
                ProductList.Add(new AreaProduct(2, "PS4", 399, "Console PS4", 10));
                ProductList.Add(new AreaProduct(3, "PS3", 299, "Console PS3", 10));
                ProductList.Add(new AreaProduct(4, "PS2", 199, "Console PS2", 10));
                ProductList.Add(new AreaProduct(5, "PS1", 99, "Console PS1", 10));
                ProductList.Add(new AreaProduct(6, "JEU ", 70, "Une couille", 50));
                ProductList.Add(new AreaProduct(7, "Manette", 60, "Manette PS5", 2));
                ProductList.Add(new AreaProduct(8, "TV", 500, "Ecran", 69));
                ProductList.Add(new AreaProduct(9, "PS4", 499, "Console PS4", 2));
                ProductList.Add(new AreaProduct(10, "JEU ", 70, "Une couille", 50));
                ProductList.Add(new AreaProduct(11, "Manette", 30, "Manette PS4", 10));
                ProductList.Add(new AreaProduct(12, "TV", 500, "Ecran", 69));
            }
            return View(ProductList);
        }
        [Route("Products/Item/{id}")]
        public IActionResult Item(int id)
        {
            List<AreaProduct> ProductList = new List<AreaProduct>();
            {
                ProductList.Add(new AreaProduct(0, "PS5", 4999, "Console PS5", 2));
                ProductList.Add(new AreaProduct(1, "PS5", 499, "Console PS5", 10));
                ProductList.Add(new AreaProduct(2, "PS4", 399, "Console PS4", 10));
                ProductList.Add(new AreaProduct(3, "PS3", 299, "Console PS3", 10));
                ProductList.Add(new AreaProduct(4, "PS2", 199, "Console PS2", 10));
                ProductList.Add(new AreaProduct(5, "PS1", 99, "Console PS1", 10));
                ProductList.Add(new AreaProduct(6, "JEU ", 70, "Une couille", 50));
                ProductList.Add(new AreaProduct(7, "Manette", 60, "Manette PS5", 2));
                ProductList.Add(new AreaProduct(8, "TV", 500, "Ecran", 69));
                ProductList.Add(new AreaProduct(9, "PS4", 499, "Console PS4", 2));
                ProductList.Add(new AreaProduct(10, "JEU ", 70, "Une couille", 50));
                ProductList.Add(new AreaProduct(11, "Manette", 30, "Manette PS4", 10));
                ProductList.Add(new AreaProduct(12, "TV", 500, "Ecran", 69));
            }
            // return View(ProductList.FirstOrDefault(ProductList.Find(id));
            return View(ProductList.FirstOrDefault(a => a.Id == id));
        }
        [Route("Products/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
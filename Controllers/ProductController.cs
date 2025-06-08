using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using myWebApp.Models;
using Kameleoon;

namespace myWebApp.Controllers
{
    public class ProductController : Controller
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
        [Route("Product")]
        public IActionResult Index()
        {

            GetExperiment(128989);
            List<Product> ProductList = new List<Product>();
            {
                ProductList.Add(new Product(0, "Lorem ipsum.", 499, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 2));
                ProductList.Add(new Product(1, "Lorem ipsum.", 499, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 10));
                ProductList.Add(new Product(2, "Dolor", 499, "Morbi et sapien eget lectus sollicitudin volutpat.", 10));
                ProductList.Add(new Product(3, "Sit amet", 499, "Phasellus dignissim diam dapibus, sagittis metus finibus, ultricies purus.", 10));
                ProductList.Add(new Product(4, "Consectetur ", 499, "Proin congue elit id maximus laoreet.", 10));
                ProductList.Add(new Product(5, "Adipiscing ", 499, "Nulla elementum sem at urna consectetur, id luctus purus lobortis.", 10));
                ProductList.Add(new Product(6, "Elit", 70, "Fusce aliquam urna nec ligula ullamcorper ultricies.", 50));
                ProductList.Add(new Product(7, "Sed", 60, "Nullam lacinia justo quis augue semper, et aliquam ligula cursus.", 20));
                ProductList.Add(new Product(8, "Quis", 500, "Vestibulum vitae dolor sit amet erat mattis hendrerit quis nec felis.", 69));
                ProductList.Add(new Product(9, "Justo ", 499, "Vivamus commodo enim nec luctus iaculis.", 2));
                ProductList.Add(new Product(10, "suscipit  ", 70, "Pellentesque vel ex eget enim commodo porttitor.", 50));
                ProductList.Add(new Product(11, "Porttitor", 60, "Integer a urna a risus volutpat interdum nec quis tortor.", 20));
                ProductList.Add(new Product(13, "Nunc tempor", 500, "Sed ac arcu sed dolor cursus bibendum ac nec diam.", 69));
                ProductList.Add(new Product(14, "Vivamus eu mi mollis", 500, "Proin mattis justo in nulla tempor posuere.", 69));
                ProductList.Add(new Product(15, "Nulla gravida", 500, "Maecenas consectetur purus vel venenatis sollicitudin.", 69));
            }
            return View(ProductList);
        }
        // [Route("Product/Product/{id:int}")]
        [Route("Product/{id:int}")]
        public IActionResult Product(int id)
        {
            List<Product> ProductList = new List<Product>();
            {
                ProductList.Add(new Product(0, "Lorem ipsum.", 499, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 2));
                ProductList.Add(new Product(1, "Lorem ipsum.", 499, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 10));
                ProductList.Add(new Product(2, "Dolor", 499, "Morbi et sapien eget lectus sollicitudin volutpat.", 10));
                ProductList.Add(new Product(3, "Sit amet", 499, "Phasellus dignissim diam dapibus, sagittis metus finibus, ultricies purus.", 10));
                ProductList.Add(new Product(4, "Consectetur ", 499, "Proin congue elit id maximus laoreet.", 10));
                ProductList.Add(new Product(5, "Adipiscing ", 499, "Nulla elementum sem at urna consectetur, id luctus purus lobortis.", 10));
                ProductList.Add(new Product(6, "Elit", 70, "Fusce aliquam urna nec ligula ullamcorper ultricies.", 50));
                ProductList.Add(new Product(7, "Sed", 60, "Nullam lacinia justo quis augue semper, et aliquam ligula cursus.", 20));
                ProductList.Add(new Product(8, "Quis", 500, "Vestibulum vitae dolor sit amet erat mattis hendrerit quis nec felis.", 69));
                ProductList.Add(new Product(9, "Justo ", 499, "Vivamus commodo enim nec luctus iaculis.", 2));
                ProductList.Add(new Product(10, "suscipit  ", 70, "Pellentesque vel ex eget enim commodo porttitor.", 50));
                ProductList.Add(new Product(11, "Porttitor", 60, "Integer a urna a risus volutpat interdum nec quis tortor.", 20));
                ProductList.Add(new Product(13, "Nunc tempor", 500, "Sed ac arcu sed dolor cursus bibendum ac nec diam.", 69));
                ProductList.Add(new Product(14, "Vivamus eu mi mollis", 500, "Proin mattis justo in nulla tempor posuere.", 69));
                ProductList.Add(new Product(15, "Nulla gravida", 500, "Maecenas consectetur purus vel venenatis sollicitudin.", 69));
            }
            // return View(ControllerContext.FirstOrDefault(id));
            return View(ProductList.FirstOrDefault(a => a.Id == id));
        }
        [Route("/Product/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
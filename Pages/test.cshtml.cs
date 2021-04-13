using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace myWebApp.Pages
{
    public class TestModel : PageModel
    {
        private readonly ILogger<TestModel> _logger;

        public TestModel(ILogger<TestModel> logger)
        {
            _logger = logger;

        }
    }
    public class Car
    {
        public string Name { get; set; }
    }
    public class ProductTest
    {
        private string name;
        private int price;
        private string info;
        private int quantity;
        public ProductTest(string name, int price, string info, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Info = info;
            this.Quantity = quantity;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Info
        {
            get { return info; }
            set { info = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

    }

}
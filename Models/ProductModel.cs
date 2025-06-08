namespace myWebApp.Models
{
    public class Product
    {
        private int id;
        private string name;
        private double price;
        private string info;
        private int quantity;
        public Product(int id, string name, double price, string info, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Info = info;
            this.Quantity = quantity;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Price
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
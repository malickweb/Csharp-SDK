namespace myWebApp.Models
{
    public class ProductsList
    {
        private int id;
        private string name;
        private int price;
        private string info;
        private int quantity;
        public ProductsList(int id, string name, int price, string info, int quantity)
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
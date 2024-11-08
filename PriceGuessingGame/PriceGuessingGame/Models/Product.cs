using System;

namespace PriceGuessingGame.Models
{
    [Serializable]
    public class Product
    {
        private string _name;
        private decimal _price;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public Product() { }

        public Product(string name, decimal price)
        {
            _name = name;
            _price = price;
        }

        public override string ToString()
        {
            return $"{_name} - {_price:N0} VND";
        }
    }
}
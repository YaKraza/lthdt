using System;
using System.Collections.Generic;

namespace PriceGuessingGame.Models
{
    public abstract class GameLevel
    {
        protected List<Product> Products;
        protected int NumberOfProducts;
        protected string LevelName;
        protected int MaxAttempts;

        public GameLevel(string levelName, int numberOfProducts, int maxAttempts)
        {
            LevelName = levelName;
            NumberOfProducts = numberOfProducts;
            MaxAttempts = maxAttempts;
            Products = new List<Product>();
        }

        public abstract void Initialize(List<Product> allProducts);
        public abstract int Play();

        protected void ShuffleProducts()
        {
            Random random = new Random();
            int n = Products.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Product temp = Products[k];
                Products[k] = Products[n];
                Products[n] = temp;
            }
        }
    }
}
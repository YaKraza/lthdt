using System.Collections.Generic;
using PriceGuessingGame.Models;

namespace PriceGuessingGame.Services
{
    public interface IDataService
    {
        List<Product> LoadProducts();
        void SaveProducts(List<Product> products);
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PriceGuessingGame.Models;

namespace PriceGuessingGame.Services
{
    public class FileDataService : IDataService
    {
        private readonly string _txtPath = "sanpham.txt";
        private readonly string _xmlPath = "sanpham.xml";

        public List<Product> LoadProducts()
        {
            if (!File.Exists(_xmlPath))
            {
                List<Product> products = LoadFromTextFile();
                SaveProducts(products);
                return products;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            using (FileStream fs = new FileStream(_xmlPath, FileMode.Open))
            {
                return (List<Product>)serializer.Deserialize(fs);
            }
        }

        public void SaveProducts(List<Product> products)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            using (FileStream fs = new FileStream(_xmlPath, FileMode.Create))
            {
                serializer.Serialize(fs, products);
            }
        }

        private List<Product> LoadFromTextFile()
        {
            if (!File.Exists(_txtPath))
            {
                throw new FileNotFoundException($"Không tìm thấy file {_txtPath}!");
            }

            List<Product> products = new List<Product>();
            string[] lines = File.ReadAllLines(_txtPath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    if (decimal.TryParse(parts[1].Trim(), out decimal price))
                    {
                        products.Add(new Product(name, price));
                    }
                }
            }

            if (products.Count == 0)
            {
                throw new Exception($"Không có dữ liệu hợp lệ trong file {_txtPath}!");
            }

            return products;
        }
    }
}
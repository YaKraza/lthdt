using System;
using System.Collections.Generic;

namespace PriceGuessingGame.Models
{
    public class HardLevel : GameLevel
    {
        public HardLevel() : base("Khó", 8, 1) { }

        public override void Initialize(List<Product> allProducts)
        {
            if (allProducts.Count < NumberOfProducts)
            {
                throw new InvalidOperationException("Không đủ sản phẩm để khởi tạo level!");
            }

            Products.Clear();
            Random random = new Random();
            List<int> selectedIndices = new List<int>();

            while (Products.Count < NumberOfProducts)
            {
                int index = random.Next(allProducts.Count);
                if (!selectedIndices.Contains(index))
                {
                    selectedIndices.Add(index);
                    Products.Add(allProducts[index]);
                }
            }

            ShuffleProducts();
        }

        public override int Play()
        {
            Console.Clear();
            Console.WriteLine($"\n=== LEVEL {LevelName.ToUpper()} ===");
            Console.WriteLine($"Hãy chọn giá đúng cho {NumberOfProducts} sản phẩm sau:");
            Console.WriteLine($"Bạn chỉ có {MaxAttempts} lượt cho mỗi sản phẩm\n");

            int score = 0;
            List<decimal> prices = Products.ConvertAll(p => p.Price);

            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"\nSản phẩm {i + 1}: {Products[i].Name}");
                Console.WriteLine("Các mức giá (VND):");

                for (int j = 0; j < prices.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {prices[j]:N0}");
                }

                Console.Write($"\nNhập lựa chọn của bạn (1-{prices.Count}): ");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= prices.Count)
                {
                    if (prices[choice - 1] == Products[i].Price)
                    {
                        Console.WriteLine("\nChính xác! +1 điểm");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Sai rồi! Giá đúng là: {Products[i].Price:N0} VND");
                    }
                }
                else
                {
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                }
            }

            return score;
        }
    }
}
using PriceGuessingGame.Managers;
using System;

namespace PriceGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                GameManager gameManager = new GameManager();
                gameManager.StartGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khởi động chương trình: {ex.Message}");
            }
        }
    }
}
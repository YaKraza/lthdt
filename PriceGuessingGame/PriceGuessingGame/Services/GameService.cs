using System;
using System.Collections.Generic;
using PriceGuessingGame.Models;

namespace PriceGuessingGame.Services
{
    public class GameService : IGameService
    {
        private readonly IDataService _dataService;
        private readonly IScoreManager _scoreManager;

        public GameService(IDataService dataService, IScoreManager scoreManager)
        {
            _dataService = dataService;
            _scoreManager = scoreManager;
        }

        public void PlayGame(GameLevel level)
        {
            try
            {
                List<Product> allProducts = _dataService.LoadProducts();
                level.Initialize(allProducts);
                int score = level.Play();
                _scoreManager.SaveScore(score);

                Console.WriteLine($"\nKết thúc level! Điểm của bạn: {score}");
                Console.WriteLine("\nNhấn Enter để tiếp tục...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi trong quá trình chơi game: {ex.Message}");
                Console.WriteLine("\nNhấn Enter để tiếp tục...");
                Console.ReadLine();
            }
        }
    }
}
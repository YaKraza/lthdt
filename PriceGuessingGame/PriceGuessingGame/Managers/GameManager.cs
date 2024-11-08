using System;
using System.Collections.Generic;
using PriceGuessingGame.Models;
using PriceGuessingGame.Services;

namespace PriceGuessingGame.Managers
{
    public class GameManager
    {
        private readonly IGameService _gameService;
        private readonly IScoreManager _scoreManager;
        private readonly IPlayerManager _playerManager;
        private readonly Player _currentPlayer;

        public GameManager()
        {
            IDataService dataService = new FileDataService();
            _scoreManager = new ScoreManager();
            _playerManager = new PlayerManager();
            _gameService = new GameService(dataService, _scoreManager);
            _currentPlayer = _playerManager.GetCurrentPlayer();
        }

        public void StartGame()
        {
            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _gameService.PlayGame(new EasyLevel());
                        break;
                    case "2":
                        _gameService.PlayGame(new MediumLevel());
                        break;
                    case "3":
                        _gameService.PlayGame(new HardLevel());
                        break;
                    case "4":
                        ShowHighScores();
                        break;
                    case "5":
                        ShowPlayerStats();
                        break;
                    case "6":
                        if (ConfirmExit())
                            return;
                        break;
                    default:
                        Console.WriteLine("\nLựa chọn không hợp lệ!");
                        Console.WriteLine("Nhấn Enter để tiếp tục...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine($"=== HÃY CHỌN GIÁ ĐÚNG ===");
            Console.WriteLine($"Xin chào, {_currentPlayer.Name}!\n");
            Console.WriteLine("1. Chơi mức Dễ (3 sản phẩm)");
            Console.WriteLine("2. Chơi mức Vừa (5 sản phẩm)");
            Console.WriteLine("3. Chơi mức Khó (8 sản phẩm)");
            Console.WriteLine("4. Xem điểm cao");
            Console.WriteLine("5. Xem thống kê");
            Console.WriteLine("6. Thoát");
            Console.Write("\nNhập lựa chọn của bạn: ");
        }

        private void ShowHighScores()
        {
            Console.Clear();
            Console.WriteLine("=== BẢNG XẾP HẠNG ĐIỂM CAO ===\n");
            List<int> highScores = _scoreManager.GetHighScores();

            if (highScores.Count == 0)
            {
                Console.WriteLine("Chưa có điểm cao nào!");
            }
            else
            {
                for (int i = 0; i < highScores.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {highScores[i]} điểm");
                }
            }

            Console.WriteLine("\nNhấn Enter để tiếp tục...");
            Console.ReadLine();
        }

        private void ShowPlayerStats()
        {
            Console.Clear();
            Console.WriteLine($"=== THỐNG KÊ NGƯỜI CHƠI ===\n");
            Console.WriteLine($"Tên người chơi: {_currentPlayer.Name}");
            Console.WriteLine($"Số lần chơi: {_currentPlayer.GamesPlayed}");
            Console.WriteLine($"Tổng điểm: {_currentPlayer.TotalScore}");
            Console.WriteLine($"Điểm trung bình: {_currentPlayer.AverageScore:F2}");

            Console.WriteLine("\nNhấn Enter để tiếp tục...");
            Console.ReadLine();
        }

        private bool ConfirmExit()
        {
            Console.Clear();
            Console.Write("Bạn có chắc muốn thoát game? (Y/N): ");
            string response = Console.ReadLine().Trim().ToUpper();
            return response == "Y";
        }
    }
}
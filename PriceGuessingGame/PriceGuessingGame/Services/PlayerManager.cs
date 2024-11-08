using System;
using System.IO;
using System.Xml.Serialization;
using PriceGuessingGame.Models;

namespace PriceGuessingGame.Services
{
    public class PlayerManager : IPlayerManager
    {
        private readonly string _playerFilePath = "player.xml";
        private Player _currentPlayer;

        public PlayerManager()
        {
            LoadPlayer();
        }

        public Player GetCurrentPlayer()
        {
            return _currentPlayer;
        }

        public void SavePlayer(Player player)
        {
            _currentPlayer = player;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Player));
                using (FileStream fs = new FileStream(_playerFilePath, FileMode.Create))
                {
                    serializer.Serialize(fs, player);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu thông tin người chơi: {ex.Message}");
            }
        }

        private void LoadPlayer()
        {
            if (!File.Exists(_playerFilePath))
            {
                CreateNewPlayer();
                return;
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Player));
                using (FileStream fs = new FileStream(_playerFilePath, FileMode.Open))
                {
                    _currentPlayer = (Player)serializer.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                CreateNewPlayer();
            }
        }

        private void CreateNewPlayer()
        {
            Console.Clear();
            Console.WriteLine("=== CHÀO MỪNG ĐẾN VỚI HÃY CHỌN GIÁ ĐÚNG ===");
            Console.Write("\nNhập tên của bạn: ");
            string playerName = Console.ReadLine().Trim();

            while (string.IsNullOrEmpty(playerName))
            {
                Console.Write("Tên không được để trống. Vui lòng nhập lại: ");
                playerName = Console.ReadLine().Trim();
            }

            _currentPlayer = new Player(playerName);
            SavePlayer(_currentPlayer);
        }
    }
}
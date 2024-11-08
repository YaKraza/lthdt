using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PriceGuessingGame.Services
{
    public class ScoreManager : IScoreManager
    {
        private List<int> _highScores;
        private readonly string _scoreFilePath = "highscores.xml";
        private const int MaxHighScores = 5;

        public ScoreManager()
        {
            _highScores = LoadHighScores();
        }

        public void SaveScore(int score)
        {
            _highScores.Add(score);
            _highScores.Sort();
            _highScores.Reverse();

            if (_highScores.Count > MaxHighScores)
            {
                _highScores = _highScores.GetRange(0, MaxHighScores);
            }

            SaveHighScores();
        }

        public List<int> GetHighScores()
        {
            return new List<int>(_highScores);
        }

        public void ClearScores()
        {
            _highScores.Clear();
            SaveHighScores();
        }

        private List<int> LoadHighScores()
        {
            if (!File.Exists(_scoreFilePath))
            {
                return new List<int>();
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<int>));
                using (FileStream fs = new FileStream(_scoreFilePath, FileMode.Open))
                {
                    return (List<int>)serializer.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                return new List<int>();
            }
        }

        private void SaveHighScores()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<int>));
                using (FileStream fs = new FileStream(_scoreFilePath, FileMode.Create))
                {
                    serializer.Serialize(fs, _highScores);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu điểm cao: {ex.Message}");
            }
        }
    }
}
using System;

namespace PriceGuessingGame.Models
{
    [Serializable]
    public class Player
    {
        private string _name;
        private int _totalScore;
        private int _gamesPlayed;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int TotalScore
        {
            get { return _totalScore; }
            set { _totalScore = value; }
        }

        public int GamesPlayed
        {
            get { return _gamesPlayed; }
            set { _gamesPlayed = value; }
        }

        public double AverageScore
        {
            get { return _gamesPlayed > 0 ? (double)_totalScore / _gamesPlayed : 0; }
        }

        public Player(string name)
        {
            _name = name;
            _totalScore = 0;
            _gamesPlayed = 0;
        }

        public void AddScore(int score)
        {
            _totalScore += score;
            _gamesPlayed++;
        }
    }
}
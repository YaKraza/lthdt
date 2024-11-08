using System.Collections.Generic;

namespace PriceGuessingGame.Services
{
    public interface IScoreManager
    {
        void SaveScore(int score);
        List<int> GetHighScores();
        void ClearScores();
    }
}
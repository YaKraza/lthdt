using PriceGuessingGame.Models;

namespace PriceGuessingGame.Services
{
    public interface IGameService
    {
        void PlayGame(GameLevel level);
    }
}

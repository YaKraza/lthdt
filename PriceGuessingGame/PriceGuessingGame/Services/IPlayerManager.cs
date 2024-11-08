using PriceGuessingGame.Models;

namespace PriceGuessingGame.Services
{
    public interface IPlayerManager
    {
        Player GetCurrentPlayer();
        void SavePlayer(Player player);
    }
}
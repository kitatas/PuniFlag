using Kai.Game.Application;

namespace Kai.Game.Data.Entity.Interface
{
    public interface IGameStateEntity
    {
        void SetState(GameState gameState);
        GameState GetGameState();
    }
}
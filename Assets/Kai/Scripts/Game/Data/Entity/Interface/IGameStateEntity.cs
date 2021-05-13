using Game.Application;

namespace Game.Data.Entity.Interface
{
    public interface IGameStateEntity
    {
        void SetState(GameState gameState);
        GameState GetGameState();
    }
}
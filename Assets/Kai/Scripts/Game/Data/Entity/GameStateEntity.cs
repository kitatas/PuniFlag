using Game.Application;
using Game.Data.Entity.Interface;

namespace Game.Data.Entity
{
    public sealed class GameStateEntity : IGameStateEntity
    {
        private GameState _gameState;

        public GameStateEntity()
        {
            _gameState = InGameConfig.INIT_STATE;
        }

        public void SetState(GameState gameState) => _gameState = gameState;

        public GameState GetGameState() => _gameState;
    }
}
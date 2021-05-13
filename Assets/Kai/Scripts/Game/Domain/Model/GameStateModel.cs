using Game.Application;
using Game.Domain.Model.Interface;
using UniRx;

namespace Game.Domain.Model
{
    public sealed class GameStateModel : IGameStateModel
    {
        private readonly ReactiveProperty<GameState> _gameState;

        public GameStateModel()
        {
            _gameState = new ReactiveProperty<GameState>(InGameConfig.INIT_STATE);
        }

        public IReadOnlyReactiveProperty<GameState> gameState => _gameState;

        public void SetGameState(GameState state)
        {
            _gameState.Value = state;
        }
    }
}
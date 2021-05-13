using Game.Application;
using Game.Data.Entity.Interface;
using Game.Domain.Model.Interface;
using Game.Domain.UseCase.Interface;
using UniRx;

namespace Game.Domain.UseCase
{
    public sealed class GameStateUseCase : IGameStateUseCase
    {
        private readonly IGameStateEntity _gameStateEntity;
        private readonly IGameStateModel _gameStateModel;

        public GameStateUseCase(IGameStateEntity gameStateEntity, IGameStateModel gameStateModel)
        {
            _gameStateEntity = gameStateEntity;
            _gameStateModel = gameStateModel;
        }

        public IReadOnlyReactiveProperty<GameState> gameState => _gameStateModel.gameState;

        public GameState GetCurrentState() => _gameStateEntity.GetGameState();

        public void SetState(GameState state)
        {
            _gameStateEntity.SetState(state);
            _gameStateModel.SetGameState(_gameStateEntity.GetGameState());
        }

        public bool IsEqual(GameState state) => GetCurrentState() == state;
    }
}
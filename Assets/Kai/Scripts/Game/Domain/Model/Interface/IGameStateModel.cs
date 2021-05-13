using Game.Application;
using UniRx;

namespace Game.Domain.Model.Interface
{
    public interface IGameStateModel
    {
        IReadOnlyReactiveProperty<GameState> gameState { get; }
        void SetGameState(GameState state);
    }
}
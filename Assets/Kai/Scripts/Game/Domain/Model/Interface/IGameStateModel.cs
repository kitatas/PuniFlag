using Kai.Game.Application;
using UniRx;

namespace Kai.Game.Domain.Model.Interface
{
    public interface IGameStateModel
    {
        IReadOnlyReactiveProperty<GameState> gameState { get; }
        void SetGameState(GameState state);
    }
}
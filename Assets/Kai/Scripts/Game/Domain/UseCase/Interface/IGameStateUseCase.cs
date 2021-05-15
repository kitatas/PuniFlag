using Kai.Game.Application;
using UniRx;

namespace Kai.Game.Domain.UseCase.Interface
{
    public interface IGameStateUseCase
    {
        IReadOnlyReactiveProperty<GameState> gameState { get; }
        GameState GetCurrentState();
        void SetState(GameState state);
        bool IsEqual(GameState state);
    }
}
using Game.Application;
using UniRx;

namespace Game.Domain.UseCase.Interface
{
    public interface IGameStateUseCase
    {
        IReadOnlyReactiveProperty<GameState> gameState { get; }
        GameState GetCurrentState();
        void SetState(GameState state);
        bool IsEqual(GameState state);
    }
}
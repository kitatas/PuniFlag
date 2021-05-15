using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Game.Application;
using Kai.Game.Domain.UseCase.Interface;
using Zenject;

namespace Kai.Game.Presentation.View.State
{
    public sealed class JudgeState : BaseState
    {
        private IStageObjectContainerUseCase _stageObjectContainerUseCase;

        [Inject]
        private void Construct(IStageObjectContainerUseCase stageObjectContainerUseCase)
        {
            _stageObjectContainerUseCase = stageObjectContainerUseCase;
        }

        public override GameState GetState() => GameState.Move;

        public override UniTask InitAsync(CancellationToken token)
        {
            return base.InitAsync(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            var isClear = await _stageObjectContainerUseCase.IsAllGoalAsync(token);

            if (isClear)
            {
                return GameState.Clear;
            }
            else
            {
                return GameState.Input;
            }
        }
    }
}
using System;
using System.Threading;
using Common;
using Cysharp.Threading.Tasks;
using Game.Application;
using Game.Domain.UseCase.Interface;
using Zenject;

namespace Game.Presentation.View.State
{
    public sealed class MoveState : BaseState
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
            // 移動・回転待ち
            await UniTask.Delay(TimeSpan.FromSeconds(Const.ROTATE_SPEED), cancellationToken: token);

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
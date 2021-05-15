using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Common.Extension;
using Kai.Game.Application;
using Kai.Game.Data.Container.Interface;
using Kai.Game.Domain.UseCase.Interface;

namespace Kai.Game.Domain.UseCase
{
    public sealed class StageObjectContainerUseCase : IStageObjectContainerUseCase
    {
        private readonly IReadOnlyPlayerContainer _playerContainer;
        private readonly IReadOnlyFlagContainer _flagContainer;

        public StageObjectContainerUseCase(IReadOnlyPlayerContainer playerContainer, IReadOnlyFlagContainer flagContainer)
        {
            _playerContainer = playerContainer;
            _flagContainer = flagContainer;
        }

        public async UniTask MoveAsync(InputType inputType, CancellationToken token)
        {
            await _playerContainer.MoveAllAsync(inputType, token);
        }

        public async UniTask RotateAsync(InputType inputType, CancellationToken token)
        {
            _playerContainer.ActivateColliderAll(false);

            await (
                _playerContainer.RotateAllAsync(inputType, token),
                _flagContainer.RotateAllAsync(inputType, token)
            );
        }

        public async UniTask<bool> IsAllGoalAsync(CancellationToken token)
        {
            _playerContainer.ActivateColliderAll(true);
            _playerContainer.SetGravityAll(false);

            await UniTask.WaitUntil(_playerContainer.IsGroundAll, cancellationToken: token);

            return _flagContainer.flagViews.All(flagView =>
                _playerContainer.playerViews
                    .Where(playerView => flagView.color == playerView.color)
                    .All(playerView => flagView.EqualPosition(playerView.transform.RoundPosition())));
        }
    }
}
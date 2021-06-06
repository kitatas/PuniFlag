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
        private readonly IReadOnlyColorBlockContainer _colorBlockContainer;

        public StageObjectContainerUseCase(IReadOnlyPlayerContainer playerContainer,
            IReadOnlyFlagContainer flagContainer, IReadOnlyColorBlockContainer colorBlockContainer)
        {
            _playerContainer = playerContainer;
            _flagContainer = flagContainer;
            _colorBlockContainer = colorBlockContainer;
        }

        public async UniTask MoveAsync(InputType inputType, CancellationToken token)
        {
            await _playerContainer.MoveAllAsync(inputType, token);
        }

        public async UniTask RotateAsync(InputType inputType, CancellationToken token)
        {
            _playerContainer.ActivateColliderAll(false);
            _colorBlockContainer.ActivateColliderAll(false);

            await (
                _playerContainer.RotateAllAsync(inputType, token),
                _flagContainer.RotateAllAsync(inputType, token),
                _colorBlockContainer.RotateAllAsync(inputType, token)
            );
        }

        public async UniTask<bool> IsAllGoalAsync(CancellationToken token)
        {
            _playerContainer.ActivateColliderAll(true);
            _playerContainer.SetGravityAll(false);

            _colorBlockContainer.ActivateColliderAll(true);
            _colorBlockContainer.SetGravityAll(false);

            await UniTask.WaitUntil(() => _playerContainer.IsGroundAll() && _colorBlockContainer.IsGroundAll(),
                cancellationToken: token);

            return _flagContainer.flagViews.All(flagView =>
                _playerContainer.playerViews
                    .Where(playerView => flagView.color == playerView.color)
                    .All(playerView => flagView.EqualPosition(playerView.transform.RoundPosition())));
        }
    }
}
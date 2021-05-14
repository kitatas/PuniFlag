using System.Linq;
using System.Threading;
using Common.Extension;
using Cysharp.Threading.Tasks;
using Game.Application;
using Game.Data.Container.Interface;
using Game.Domain.UseCase.Interface;

namespace Game.Domain.UseCase
{
    public sealed class StageObjectContainerUseCase : IStageObjectContainerUseCase
    {
        private readonly IPlayerContainer _playerContainer;
        private readonly IFlagContainer _flagContainer;

        public StageObjectContainerUseCase(IPlayerContainer playerContainer, IFlagContainer flagContainer)
        {
            _playerContainer = playerContainer;
            _flagContainer = flagContainer;
        }

        public void Move(InputType inputType)
        {
            _playerContainer.MoveAll(inputType);
        }

        public void Rotate(InputType inputType)
        {
            _playerContainer.ActivateColliderAll(false);
            _playerContainer.RotateAll(inputType);
            _flagContainer.RotateAll(inputType);
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
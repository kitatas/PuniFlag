using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Game.Application;
using Kai.Game.Data.Container.Interface;
using Kai.Game.Presentation.View;

namespace Kai.Game.Data.Container
{
    public sealed class PlayerContainer : IReadOnlyPlayerContainer, IWriteOnlyPlayerContainer
    {
        private readonly List<PlayerView> _playerViews;

        public PlayerContainer()
        {
            _playerViews = new List<PlayerView>();
        }

        public IEnumerable<PlayerView> playerViews => _playerViews;

        public void Add(PlayerView playerView)
        {
            playerView.Init();
            _playerViews.Add(playerView);
        }

        public async UniTask MoveAllAsync(InputType inputType, CancellationToken token)
        {
            await Enumerable
                .Select(playerViews, playerView => playerView.MoveAsync(inputType, token))
                .ToList();
        }

        public void ActivateColliderAll(bool value)
        {
            foreach (var playerView in playerViews)
            {
                playerView.ActivateCollider(value);
            }
        }

        public async UniTask RotateAllAsync(InputType inputType, CancellationToken token)
        {
            await Enumerable
                .Select(playerViews, playerView => playerView.RotateAsync(inputType, token))
                .ToList();
        }

        public void SetGravityAll(bool value)
        {
            foreach (var playerView in playerViews)
            {
                playerView.isGround = value;
            }
        }

        public bool IsGroundAll() => playerViews.All(player => player.isGround);
    }
}
using System.Collections.Generic;
using System.Linq;
using Game.Application;
using Game.Data.Container.Interface;
using Game.Presentation.View;

namespace Game.Data.Container
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

        public void MoveAll(InputType inputType)
        {
            foreach (var playerView in playerViews)
            {
                playerView.Move(inputType);
            }
        }

        public void ActivateColliderAll(bool value)
        {
            foreach (var playerView in playerViews)
            {
                playerView.ActivateCollider(value);
            }
        }

        public void RotateAll(InputType inputType)
        {
            foreach (var playerView in playerViews)
            {
                playerView.Rotate(inputType);
            }
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
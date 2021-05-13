using System;
using System.Linq;
using System.Threading;
using Common;
using Cysharp.Threading.Tasks;
using Game.Application;
using Game.Player;

namespace Game.Presentation.View.State
{
    public sealed class MoveState : BaseState
    {
        private PlayerCore[] _players;

        private void Awake()
        {
            _players = FindObjectsOfType<PlayerCore>();
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

            SetOnGravity();

            await UniTask.WaitUntil(IsGroundAllPlayer, cancellationToken: token);

            if (IsGoalAllPlayer())
            {
                return GameState.Clear;
            }
            else
            {
                return GameState.Input;
            }
        }

        private void SetOnGravity()
        {
            foreach (var player in _players)
            {
                player.isGround = false;
            }
        }

        private bool IsGroundAllPlayer()
        {
            return _players.All(player => player.isGround);
        }

        private bool IsGoalAllPlayer()
        {
            return _players.All(player => player.IsGoal());
        }
    }
}
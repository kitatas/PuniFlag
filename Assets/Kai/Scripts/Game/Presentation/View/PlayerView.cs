using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Kai.Common.Extension;
using Kai.Game.Application;
using Kai.Game.Domain.UseCase;
using Kai.Game.Domain.UseCase.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Kai.Game.Presentation.View
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerSpriteView))]
    public sealed class PlayerView : StageObjectView
    {
        [SerializeField] private ColorType colorType = default;
        [SerializeField] private Collider2D collider2d = default;
        [SerializeField] private Rigidbody2D rigidbody2d = default;
        [SerializeField] private PlayerSpriteView playerSpriteView = default;
        public bool isGround;
        private TweenerCore<Vector3, Vector3, VectorOptions> _tween;

        private IPlayerMoveUseCase _playerMoveUseCase;
        private IStageObjectRotateUseCase _stageObjectRotateUseCase;

        public void Init()
        {
            isGround = false;
            _playerMoveUseCase = new PlayerMoveUseCase(color, rigidbody2d, transform);
            _stageObjectRotateUseCase = new StageObjectRotateUseCase(transform);

            // 落下
            this.FixedUpdateAsObservable()
                .Where(_ => isGround == false)
                .Subscribe(_ =>
                {
                    _playerMoveUseCase.UpdateGravity();
                })
                .AddTo(this);

            // 接地したら位置を補正
            this.OnCollisionEnter2DAsObservable()
                .Subscribe(_ =>
                {
                    _tween?.Kill();

                    var roundPosition = transform.RoundPosition();
                    transform
                        .DOMove(roundPosition, StageObjectConfig.CORRECT_TIME)
                        .OnComplete(() =>
                        {
                            isGround = true;
                            _playerMoveUseCase.ResetVelocity();
                        });
                })
                .AddTo(this);
        }

        public void ActivateCollider(bool value)
        {
            collider2d.enabled = value;
        }

        public async UniTask MoveAsync(InputType inputType, CancellationToken token)
        {
            _tween = _playerMoveUseCase.Move(inputType);
            playerSpriteView.Flip(inputType);

            await UniTask.Delay(TimeSpan.FromSeconds(StageObjectConfig.MOVE_SPEED), cancellationToken: token);
        }

        public async UniTask RotateAsync(InputType inputType, CancellationToken token)
        {
            await _stageObjectRotateUseCase.RotateAsync(inputType, token);
        }

        public override StageObjectType type => StageObjectType.Player;
        public override ColorType color => colorType;
    }
}
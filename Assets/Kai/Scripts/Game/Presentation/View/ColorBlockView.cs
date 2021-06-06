using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Kai.Common.Extension;
using Kai.Game.Application;
using Kai.Game.Domain.UseCase;
using Kai.Game.Domain.UseCase.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Kai.Game.Presentation.View
{
    public sealed class ColorBlockView : BlockView
    {
        [SerializeField] private Collider2D collider2d = default;
        [SerializeField] private Rigidbody2D rigidbody2d = default;
        public bool isGround;

        private IStageObjectDropUseCase _stageObjectDropUseCase;
        private IStageObjectRotateUseCase _stageObjectRotateUseCase;

        public void Init()
        {
            isGround = false;
            _stageObjectDropUseCase = new StageObjectDropUseCase(rigidbody2d);
            _stageObjectRotateUseCase = new StageObjectRotateUseCase(transform);

            this.FixedUpdateAsObservable()
                .Where(_ => isGround == false)
                .Subscribe(_ =>
                {
                    // 
                    _stageObjectDropUseCase.UpdateGravity(color);
                })
                .AddTo(this);

            this.OnCollisionEnter2DAsObservable()
                .Subscribe(_ =>
                {
                    var roundPosition = transform.RoundPosition();
                    transform
                        .DOMove(roundPosition, StageObjectConfig.CORRECT_TIME)
                        .OnComplete(() =>
                        {
                            isGround = true;
                            _stageObjectDropUseCase.ResetVelocity();
                        });
                })
                .AddTo(this);
        }

        public void ActivateCollider(bool value)
        {
            collider2d.enabled = value;
        }

        public async UniTask RotateAsync(InputType inputType, CancellationToken token)
        {
            await _stageObjectRotateUseCase.RotateAsync(inputType, token);
        }
    }
}
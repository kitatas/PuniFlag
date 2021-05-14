using System.Linq;
using Common;
using Common.Extension;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Game.Application;
using Game.Domain.UseCase;
using Game.Domain.UseCase.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Game.Presentation.View
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerSpriteView))]
    public sealed class PlayerView : StageObjectView
    {
        [SerializeField] private ColorType colorType = default;
        public bool isGround;
        private TweenerCore<Vector3, Vector3, VectorOptions> _tween;

        private FlagView _flagView;

        private FlagView flagView
        {
            get
            {
                if (_flagView == null)
                {
                    var flags = FindObjectsOfType<FlagView>();
                    _flagView = flags.ToList().Find(x => x.color == color);
                }

                return _flagView;
            }
        }

        private Collider2D _collider2D;
        private PlayerSpriteView _playerSpriteView;
        private IPlayerMoveUseCase _playerMoveUseCase;
        private IStageObjectRotateUseCase _stageObjectRotateUseCase;

        private void Awake()
        {
            _collider2D = GetComponent<Collider2D>();
            _playerSpriteView = GetComponent<PlayerSpriteView>();
            var rigidbody2d = GetComponent<Rigidbody2D>();
            _playerMoveUseCase = new PlayerMoveUseCase(color, rigidbody2d, transform);
            _stageObjectRotateUseCase = new StageObjectRotateUseCase(transform);
        }

        private void Start()
        {
            isGround = false;

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
                        .DOMove(roundPosition, Const.CORRECT_TIME)
                        .OnComplete(() =>
                        {
                            isGround = true;
                            _playerMoveUseCase.ResetVelocity();
                        });
                })
                .AddTo(this);
        }

        public bool IsGoal() => flagView.EqualPosition(transform.RoundPosition());

        public void ActivateCollider(bool value)
        {
            _collider2D.enabled = value;
        }

        public void Move(InputType inputType)
        {
            _tween = _playerMoveUseCase.Move(inputType);
            _playerSpriteView.Flip(inputType);
        }

        public void Rotate(InputType inputType)
        {
            _stageObjectRotateUseCase.Rotate(inputType);
            flagView.Rotate(inputType);
        }

        public override StageObjectType type => StageObjectType.Player;
        public override ColorType color => colorType;
    }
}
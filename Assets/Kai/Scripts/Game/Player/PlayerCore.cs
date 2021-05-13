using System.Linq;
using Common;
using Common.Extension;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Game.Application;
using Game.Presentation.View;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerView))]
    public sealed class PlayerCore : StageObjectView
    {
        [SerializeField] private ColorType colorType = default;
        [SerializeField] private PlayerType playerType = default;
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
        private PlayerView _playerView;
        private PlayerMover _playerMover;
        private PlayerRotator _playerRotator;

        private void Awake()
        {
            _collider2D = GetComponent<Collider2D>();
            _playerView = GetComponent<PlayerView>();
            var rigidbody2d = GetComponent<Rigidbody2D>();
            _playerMover = new PlayerMover(playerType, rigidbody2d, transform);
            _playerRotator = new PlayerRotator(transform);
        }

        private void Start()
        {
            isGround = false;

            // 落下
            this.FixedUpdateAsObservable()
                .Where(_ => isGround == false)
                .Subscribe(_ =>
                {
                    _playerMover.UpdateGravity();
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
                            _playerMover.ResetVelocity();
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
            _tween = _playerMover.Move(inputType);
            _playerView.Flip(inputType);
        }

        public void Rotate(InputType inputType)
        {
            _playerRotator.Rotate(inputType);
            flagView.Rotate(inputType);
        }

        public override StageObjectType type => StageObjectType.Player;
        public override ColorType color => colorType;
    }
}
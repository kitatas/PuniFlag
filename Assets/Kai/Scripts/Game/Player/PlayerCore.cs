using Common;
using Common.Extension;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Game.Stage;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerView))]
    public sealed class PlayerCore : MonoBehaviour
    {
        [SerializeField] private PlayerType playerType = default;
        [SerializeField] private Flag flag = default;
        public bool isGround;
        private TweenerCore<Vector3, Vector3, VectorOptions> _tween;

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

        public bool IsGoal() => flag.EqualPosition(transform.RoundPosition());

        public void ActivateCollider(bool value)
        {
            _collider2D.enabled = value;
        }

        public void Move(MoveDirection moveDirection)
        {
            _tween = _playerMover.Move(moveDirection);
            _playerView.Flip(moveDirection);
        }

        public void Rotate(RotateDirection rotateDirection)
        {
            _playerRotator.Rotate(rotateDirection);
            flag.Rotate(rotateDirection);
        }
    }
}
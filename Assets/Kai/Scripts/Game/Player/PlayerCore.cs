using Common;
using Common.Extension;
using DG.Tweening;
using Game.Stage;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PlayerCore : MonoBehaviour
    {
        [SerializeField] private PlayerType playerType = default;
        public bool isGround;

        private Collider2D _collider2D;
        private PlayerMover _playerMover;
        private PlayerRotator _playerRotator;

        private void Awake()
        {
            _collider2D = GetComponent<Collider2D>();
            var rigidbody2d = GetComponent<Rigidbody2D>();
            _playerMover = new PlayerMover(playerType, rigidbody2d);
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
                .Where(_ => isGround == false)
                .Subscribe(_ =>
                {
                    isGround = true;

                    var roundPosition = transform.RoundPosition();
                    transform
                        .DOMove(roundPosition, Const.CORRECT_TIME)
                        .OnComplete(() => _playerMover.ResetVelocity());
                })
                .AddTo(this);
        }

        public void ActivateCollider(bool value)
        {
            _collider2D.enabled = value;
        }

        public void Rotate(RotateDirection rotateDirection)
        {
            _playerRotator.Rotate(rotateDirection);
        }
    }
}
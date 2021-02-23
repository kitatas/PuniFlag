using Common;
using Common.Extension;
using DG.Tweening;
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

        private Rigidbody2D _rigidbody2D;
        private Collider2D _collider2D;
        private PlayerMover _playerMover;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<Collider2D>();
            _playerMover = new PlayerMover(playerType, _rigidbody2D);
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
                    isGround = true;

                    var roundPosition = transform.RoundPosition();
                    transform
                        .DOMove(roundPosition, Const.CORRECT_TIME)
                        .SetEase(Ease.Linear);
                })
                .AddTo(this);
        }

        public void ActivateCollider(bool value)
        {
            _collider2D.enabled = value;
        }
    }
}
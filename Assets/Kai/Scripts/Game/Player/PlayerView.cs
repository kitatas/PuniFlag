using System;
using Common;
using UniRx;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private Sprite normal = default;
        [SerializeField] private Sprite movement = default;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetNormal()
        {
            _spriteRenderer.sprite = normal;
        }

        public void SetMovement()
        {
            _spriteRenderer.sprite = movement;
        }

        public void Flip(MoveDirection moveDirection)
        {
            switch (moveDirection)
            {
                case MoveDirection.Left:
                    _spriteRenderer.flipX = true;
                    break;
                case MoveDirection.Right:
                    _spriteRenderer.flipX = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(moveDirection), moveDirection, null);
            }

            SetMovement();
            Observable
                .Timer(TimeSpan.FromSeconds(Const.MOVE_SPEED))
                .Subscribe(_ => SetNormal())
                .AddTo(this);
        }
    }
}
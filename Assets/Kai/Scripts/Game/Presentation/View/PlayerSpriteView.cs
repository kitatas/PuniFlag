using System;
using Common;
using Game.Application;
using UniRx;
using UnityEngine;

namespace Game.Presentation.View
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class PlayerSpriteView : MonoBehaviour
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

        public void Flip(InputType inputType)
        {
            switch (inputType)
            {
                case InputType.MoveLeft:
                    _spriteRenderer.flipX = true;
                    break;
                case InputType.MoveRight:
                    _spriteRenderer.flipX = false;
                    break;
                case InputType.None:
                case InputType.RotateLeft:
                case InputType.RotateRight:
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }

            SetMovement();
            Observable
                .Timer(TimeSpan.FromSeconds(Const.MOVE_SPEED))
                .Subscribe(_ => SetNormal())
                .AddTo(this);
        }
    }
}
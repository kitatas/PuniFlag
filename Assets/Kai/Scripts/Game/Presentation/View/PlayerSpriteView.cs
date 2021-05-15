using System;
using Kai.Game.Application;
using UniRx;
using UnityEngine;

namespace Kai.Game.Presentation.View
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class PlayerSpriteView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer = default;
        [SerializeField] private Sprite normal = default;
        [SerializeField] private Sprite movement = default;

        public void SetNormal()
        {
            spriteRenderer.sprite = normal;
        }

        public void SetMovement()
        {
            spriteRenderer.sprite = movement;
        }

        public void Flip(InputType inputType)
        {
            switch (inputType)
            {
                case InputType.MoveLeft:
                    spriteRenderer.flipX = true;
                    break;
                case InputType.MoveRight:
                    spriteRenderer.flipX = false;
                    break;
                case InputType.None:
                case InputType.RotateLeft:
                case InputType.RotateRight:
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }

            SetMovement();
            Observable
                .Timer(TimeSpan.FromSeconds(StageObjectConfig.MOVE_SPEED))
                .Subscribe(_ => SetNormal())
                .AddTo(this);
        }
    }
}